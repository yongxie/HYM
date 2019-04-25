using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DBUtil;
using System.Data.SqlClient;
using System.Configuration;

namespace UtilLib
{
    /// <summary>
    /// 商品分类数据表类(GoodsCategory)
    /// </summary>
    public class GoodsCategoryDB
    {
        public string GoodsCategoryId;
        public string Description;
        public string FatherId;
    }

    /// <summary>
    /// 商品分类数据表操作类(GoodsCategory)
    /// </summary>
    public class GoodsCategory
    {
        /// <summary>
        /// 获取商品分类信息(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("GoodsCategory");
            try
            {
//                dt = db.GetDataTable(@"  select child.GoodsCategoryId,child.FatherId,child.Description,parent.Description as FatherName
// 
// FROM Goods_Category child left join Goods_Category parent  on parent.GoodsCategoryId=child.FatherId");
                dt = db.GetDataTable(@"select GoodsCategoryId,Description,FatherId from Goods_Category");
                return dt;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告:查询商品分类信息失败!");
                return null;
            }
        }

        /// <summary>
        /// 删除商品分类信息
        /// </summary>
        /// <param name="CateId">商品分类ID</param>
        /// <returns></returns>
        public bool DelCate(string CateId)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from Goods where GoodsCategoryId='" + CateId + "'").ToString();
                int count = int.Parse(sql);
                if (count > 0)
                {
                    Common.ShowMsg("系统警告：禁止删除存在商品的分类！");
                    return false;
                   
                }
                sql = db.GetValue("select COUNT(*) from Goods_Category where FatherId='" + CateId + "'").ToString();
                count = int.Parse(sql);
                if (count > 0)
                {
                    Common.ShowMsg("系统警告：禁止删除存在子节点的分类！");
                    return false;

                }
                
                    int ReturnValue = -1;
                    db.Transact("delete Goods_Category where GoodsCategoryId = '" + CateId + " '",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("删除商品分类数据出错!");
                    else
                        return true;
                
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：删除商品分类数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool UpdateCate(string CateId, string Description, string FatherId)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from Goods_Category where Description='" + Description + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact("update Goods_Category set FatherId='" + FatherId + "',Description='" + Description + "' where GoodsCategoryId='" + CateId + "'",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("更新商品分类数据出错!");
                    else
                        return true;
                    
                }
                else
                {
                    Common.ShowMsg("系统警告：修改商品分类数据失败，此商品分类名称数据已经存在！");
                    return false;
                }
            }
            catch
            {
                Common.ShowMsg("系统警告：更新商品分类数据信息失败！");
                return false;
            }
        }

        public bool AddCate(string Description, string FatherId)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from Goods_Category where Description='" + Description + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact(@"insert into Goods_Category (Description,FatherId)  
                values('" + Description + "','" + FatherId + "')",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("新增商品分类数据出错!");
                    else
                        return true;
                }
                else
                {
                    Common.ShowMsg("系统警告：新增商品分类数据失败，此商品分类数据已经存在！");
                    return false;
                }
            }
            catch
            {
                Common.ShowMsg("系统警告：新增商品分类数据失败，可能此商品分类数据已经存在！");
                return false;
            }
        }

        /// <summary>
        /// 根据商品分类查询该级别信息
        /// </summary>
        /// <param name="CardID">商品分类ID</param>
        /// <returns>返回商品分类数据表类</returns>
        public GoodsCategoryDB FindCate(string CateId)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();
                dt = db.GetDataTable("select * from Goods_Category where GoodsCategoryId='" + CateId + "'");
                GoodsCategoryDB CateDB = new GoodsCategoryDB();
                if (dt.Rows.Count > 0)
                {
                    CateDB.GoodsCategoryId = CateId;
                    CateDB.Description = Common.CNullToStr(dt.Rows[0]["Description"]);
                    CateDB.FatherId = Common.CNullToStr(dt.Rows[0]["FatherId"]);
                }
                return CateDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询商品分类信息失败！");
                Common.ErrLog(exc.ToString());
                return new GoodsCategoryDB();
            }
        }
    }
}
