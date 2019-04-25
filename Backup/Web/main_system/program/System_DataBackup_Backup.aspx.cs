using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;
using System.IO;
using System.Data;

namespace Web.main_system.program
{
    public partial class System_DataBackup_Backup : System.Web.UI.Page
    {
        private const string BackupPath = @"..\..\sysfile\dbbak\";
        private const string DatabaseName = "HYM";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //程序模块权限验证
                Authorization clsRighter = new Authorization("0603");
                //btnSave.Enabled = clsRighter.Modify | clsRighter.Add;
                if (!clsRighter.Add)
                {
                    this.btnSave.Visible = true;
                }
                if (!clsRighter.Delete)
                {
                    int icount = this.MyDataGrid.Columns.Count;
                    this.MyDataGrid.Columns[icount - 1].Visible = false;
                }
                //btnCancel.Enabled = clsRighter.Read;
                //btnDelete.Enabled = clsRighter.Delete;
                if (CheckFolder())
                {
                    BindDataGrid();
                    btnSave.Enabled = true;				//启用确定备份按钮
                    //btnDelete.Enabled = true;			//启用删除备份按钮
                   // btnCancel.Enabled = true;			//启用取消按钮
                }
                else
                {
                    btnSave.Enabled = false;			//禁止确定备份按钮
                    //btnDelete.Enabled = false;			//禁止删除备份按钮
                   // btnCancel.Enabled = false;			//禁止取消按钮
                }
            }
        }

        /// <summary>
        /// 检查备份文件目录是否存在
        /// </summary>
        /// <returns></returns>
        private bool CheckFolder()
        {
            bool blnFolderCanUse = true;
            string strMessage = "";
            if (!Directory.Exists(Server.MapPath(BackupPath)))
            {
                strMessage = "系统提示：备份文件夹不存在";
                DirectoryInfo dirBackup = Directory.CreateDirectory(Server.MapPath(BackupPath));
                if (!dirBackup.Exists)
                {
                    strMessage += ",系统不能新建备份文件夹，请联系管理员!";
                    blnFolderCanUse = false;
                }
                else
                {
                    strMessage += ",系统已自动新建备份文件夹!";
                }
                Common.ShowMsg(strMessage);
            }
            return blnFolderCanUse;
        }

        /// <summary>
        /// 绑定数据到DataGrid控件MyDataGrid上
        /// </summary>		
        private void BindDataGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FileName", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("FileSize", Type.GetType("System.Int64")));
            dt.Columns.Add(new DataColumn("CreateDate", Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("LastModifyDate", Type.GetType("System.DateTime")));

            DirectoryInfo dir = new DirectoryInfo(Server.MapPath(BackupPath));
            foreach (FileSystemInfo fsi in dir.GetFileSystemInfos())
            {
                try
                {
                    DateTime CreateTime = fsi.CreationTime;
                    DateTime ModifyTime = fsi.LastWriteTime;
                    int subLength = 25;
                    if (fsi is FileInfo)
                    {
                        DataRow drTmp = dt.NewRow();
                        FileInfo f = (FileInfo)fsi;
                        //此 if 语句只是确保不要将文件的名称变得太短！
                        if (f.Name.Length < subLength)
                            subLength = f.Name.Length;
                        drTmp[0] = f.Name.Substring(0, subLength);
                        drTmp[1] = (f.Length)/1024;
                        drTmp[2] = CreateTime;
                        drTmp[3] = ModifyTime;
                        dt.Rows.Add(drTmp);
                    }
                }
                catch (Exception)
                {
                    Common.ShowMsg("系统提示：查询文件列表失败！");
                }
            }
            if (dt != null)
            {
                int intCountRecNum = dt.Rows.Count;	//获取数据表记录数				
                MyDataGrid.DataSource = dt.DefaultView;
                MyDataGrid.DataBind();
                lblRecNum.Text = intCountRecNum.ToString();	//显示总记录数
                ShowStats();								//显示页数信息
            }
        }


        #region 控件分页信息
        /// <summary>
        /// 显示页面页数信息
        /// </summary>
        private void ShowStats()
        {
            int intCurrentPage = (int)MyDataGrid.CurrentPageIndex;
            //显示当前页数
            lblCurrentPage.Text = Convert.ToString(intCurrentPage + 1);	//显示当前页数
            lblTotalPage.Text = MyDataGrid.PageCount.ToString();		//显示总页数
            //绑定页数到下拉框
            this.ddlCurrentPage.Items.Clear();
            for (int i = 0; i < MyDataGrid.PageCount; i++)
                this.ddlCurrentPage.Items.Add(new ListItem(Convert.ToString(i + 1), i.ToString()));
            this.ddlCurrentPage.SelectedIndex = intCurrentPage;			//指定当前页

            if (MyDataGrid.PageCount > 1)
            {
                //控制链接按钮显示状态
                if (MyDataGrid.CurrentPageIndex == (MyDataGrid.PageCount - 1))
                {
                    this.lnkFirst.Visible = true;
                    this.lnkPrevious.Visible = true;
                    this.lnkNext.Visible = false;
                    this.lnkLast.Visible = false;
                }
                else if (MyDataGrid.CurrentPageIndex == 0)
                {
                    this.lnkFirst.Visible = false;
                    this.lnkPrevious.Visible = false;
                    this.lnkNext.Visible = true;
                    this.lnkLast.Visible = true;
                }
                else
                {
                    this.lnkFirst.Visible = true;
                    this.lnkPrevious.Visible = true;
                    this.lnkNext.Visible = true;
                    this.lnkLast.Visible = true;
                }
            }
            else
            {
                this.lnkNext.Visible = false;
                this.lnkLast.Visible = false;
                this.lnkFirst.Visible = false;
                this.lnkPrevious.Visible = false;
            }
        }

        #endregion

        /// <summary>
        /// DataGrid选择项响应事件方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void DataOperate(object source, DataGridCommandEventArgs e)
        {
            //删除数据备份
            if (e.CommandName == "Delete")
            {
                string strBackupPath = Server.MapPath(BackupPath)+((Label)e.Item.Cells[0].Controls[1]).Text;
                FileInfo fi = new FileInfo(strBackupPath);
                fi.Delete();

                RecordOperate.SaveRecord(Session["UserID"].ToString(), "删除数据库备份", "删除指定数据库备份文件;文件名：" + ((Label)e.Item.Cells[0].Controls[1]).Text);
                Common.ShowMsg("系统提示：删除数据备份文件成功!");
            }

            BindDataGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //string strBackupPath = Server.MapPath(BackupPath) + txtFileName.Text;
                string strBackupPath = Server.MapPath(BackupPath);
                Backup clsBackup = new Backup();
                if (clsBackup.BackupData(DatabaseName, strBackupPath))
                {


                    BindDataGrid();
                    RecordOperate.SaveRecord(Session["UserID"].ToString(), "备份数据", "备份数据库文件");
                    Common.ShowMsg("数据库已成功备份！");
                    //txtFileName.Text = "";
                    //btnDelete.Visible = false;
                    btnSave.Text = "确定备份";
                }
                else
                {
                    Common.ShowMsg("备份失败!");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //txtFileName.Text = "";
            //btnDelete.Visible = false;
            btnSave.Text = "确定备份";
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string strBackupPath = Server.MapPath(BackupPath) + txtFileName.Text;
        //    try
        //    {
        //        FileInfo fi = new FileInfo(strBackupPath);
        //        fi.Delete();

        //        RecordOperate.SaveRecord(Session["UserID"].ToString(), "删除数据库备份", "删除指定数据库备份文件;文件名：" + txtFileName.Text);
        //        Common.ShowMsg("系统提示：删除数据备份文件成功!");
        //    }
        //    catch//(Exception exc)
        //    {
        //        Common.ShowMsg("系统警告：删除数据备份文件" + txtFileName.Text + "不成功!");
        //        //Common.ErrLog(exc.ToString());
        //    }
        //    BindDataGrid();
        //}

        protected void lnkFirst_Click(object sender, EventArgs e)
        {
            String arg = (((LinkButton)sender).CommandArgument);
            switch (arg)
            {
                case ("Next"):		//下一页
                    if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
                        MyDataGrid.CurrentPageIndex++;
                    break;
                case ("Previous"):	//上一页
                    if (MyDataGrid.CurrentPageIndex > 0)
                        MyDataGrid.CurrentPageIndex--;
                    break;
                case ("Last"):		//尾页
                    MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
                    break;
                default:			//首页
                    //本页值
                    MyDataGrid.CurrentPageIndex = 0;
                    break;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }

        protected void ddlCurrentPage_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int intCurrentPage = int.Parse(ddlCurrentPage.SelectedItem.Value);
            if (intCurrentPage < MyDataGrid.PageCount)
            {
                MyDataGrid.CurrentPageIndex = intCurrentPage;
            }
            BindDataGrid();			//重新绑定数据到DataGrid
        }



    }
}