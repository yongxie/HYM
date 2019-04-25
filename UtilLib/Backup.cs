using System;
using System.Collections.Generic;
using System.Text;
using DBUtil;
using System.Data.SqlClient;
using System.Data;

namespace UtilLib
{
    public class Backup
    {
        /// <summary>
        /// 系统数据备份
        /// </summary>
        /// <param name="DataBaseName">数据库名称</param>
        /// <param name="BackupPath">备份路径</param>
        /// <param name="BackupType">备份类型（0完全备份，1差异备份）</param>
        /// 
        public bool BackupData(string DataBaseName, string BackupPath)
        {
            //获取配置文件中sql数据库名 
            string dbName = DataBaseName;
            string name = dbName + DateTime.Now.ToString("yyyyMMddHHmmss");
            string sql;
            //创建连接对象 
            DBManager db = DBManager.Instance();//通用数据操作类		

            //删除逻辑备份设备，但不会删掉备份的数据库文件 
            SqlCommand cmd = new SqlCommand("sp_dropdevice");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@logicalname", SqlDbType.VarChar, 20);
            p.SqlValue = dbName;
            p.Direction = ParameterDirection.Input;


            cmd.Parameters.Add(p);
            try
            {
                db.Transact(cmd);//如果逻辑设备不存在，略去错误 
            }
            catch (Exception exc)
            {
                //Common.ShowMsg("系统警告：错误的备份文件目录!");
                //Common.ErrLog(exc.ToString());
            }


            //创建逻辑备份设备 
            cmd = new SqlCommand("sp_addumpdevice");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@devtype", SqlDbType.VarChar, 20);
            p1.SqlValue = "disk";
            p1.Direction = ParameterDirection.Input;


            SqlParameter p2 = new SqlParameter("@logicalname", SqlDbType.VarChar, 20);//逻辑设备名 
            p2.SqlValue = dbName;
            p2.Direction = ParameterDirection.Input;

            SqlParameter p3 = new SqlParameter("@physicalname", SqlDbType.NVarChar, 260);//物理设备名 
            p3.SqlValue = BackupPath + name + ".bak";
            p3.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(p1);

            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            try
            {
                db.Transact(cmd);
            }
            catch (Exception exc)
            {
                //Common.ShowMsg("系统警告：错误的备份文件目录!");
                //Common.ErrLog(exc.ToString());
                //throw exc;
            }

            sql = "BACKUP DATABASE " + dbName + " TO " + dbName + " WITH INIT";
            try
            {
                db.Transact(sql);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// 系统数据恢复
        /// </summary>
        /// <param name="DataBaseName">数据库名称</param>
        /// <param name="BackupPath">待恢复的备份文件名</param>
        /// 
        public bool RestoreData(string DataBaseName, string BackupPath, string BKFile)
        {
            //sql数据库名 
            string dbName = DataBaseName;
            //创建连接对象 
            DBManager db = DBManager.Instance();
            //还原指定的数据库文件 
            string sql = string.Format("use master ;declare @s varchar(8000);select @s=isnull(@s,'')+' kill '+rtrim(spID) from master..sysprocesses where dbid=db_id('{0}');select @s;exec(@s) ;RESTORE DATABASE {1} FROM DISK = N'{2}' with replace", dbName, dbName, BackupPath + BKFile);


            try
            {
                db.Transact(sql);
            }
            catch (Exception err)
            {
                return false;
            }
            return true;





    
            //DBManager db = DBManager.Instance();//通用数据操作类			

            //SqlCommand cmd = new SqlCommand("HYM_System_DB_Restore");
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter p1 = new SqlParameter("@dbname", SqlDbType.NVarChar, 50);
            ////p1.SqlValue = DataBaseName;
            //p1.SqlValue = DBNull.Value;
            //p1.Direction = ParameterDirection.Input;

            //SqlParameter p2 = new SqlParameter("@dbpath", SqlDbType.NVarChar, 260);
            //p2.SqlValue = BackupPath;
            //p2.Direction = ParameterDirection.Input;


            //SqlParameter p3 = new SqlParameter("@bkfile", SqlDbType.NVarChar, 1000);
            //p3.SqlValue = BKFile;
            //p3.Direction = ParameterDirection.Input;

            //SqlParameter p4 = new SqlParameter("@retype", SqlDbType.NVarChar, 10);
            ////p4.SqlValue = "DB";
            //p4.SqlValue = DBNull.Value;
            //p4.Direction = ParameterDirection.Input;


            //SqlParameter p5 = new SqlParameter("@filenumber", SqlDbType.Int);
            ////p5.SqlValue = 1;
            //p5.SqlValue = DBNull.Value;
            //p5.Direction = ParameterDirection.Input;

            //SqlParameter p6 = new SqlParameter("@overexist", SqlDbType.Bit);
            ////p6.SqlValue = 1;
            //p6.SqlValue = DBNull.Value;
            //p6.Direction = ParameterDirection.Input;

            //SqlParameter p7 = new SqlParameter("@killuser", SqlDbType.Bit);
            ////p7.SqlValue = 1;
            //p7.SqlValue = DBNull.Value;
            //p7.Direction = ParameterDirection.Input;


            //cmd.Parameters.Add(p1);

            //cmd.Parameters.Add(p2);
            //cmd.Parameters.Add(p3);
            ////cmd.Parameters.Add(p4);

            ////cmd.Parameters.Add(p5);
            ////cmd.Parameters.Add(p6); 
            ////cmd.Parameters.Add(p7);

            
            //try
            //{
            //    db.Transact(cmd);
            //}
            //catch (Exception exc)
            //{
            //    Common.ShowMsg("系统警告：系统数据恢复失败!");
            //    //Common.ErrLog(exc.ToString());
            //}
        }
    }
}
