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
    /// 商品数据表类(Goods)
    /// </summary>
    public class GoodsDB
    {
        public string GoodsId;
        public string GoodsName;
        public string Code;
        public double Price;
        public string GoodsCategoryId;
        public string Description;
    }

    /// <summary>
    /// 商品数据表操作类(Goods)
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 用于显示商品类别名称(用于DataGrid绑定)
        /// </summary>
        public DataTable ShowCate()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable();
            try
            {
                dt = db.GetDataTable(" select GoodsCategoryId,description from Goods_Category ");
                return dt;
            }
            catch
            {
                Common.ShowMsg("系统警告:查询商品类别失败!");
                return null;
            }
        }

        /// <summary>
        /// 获取商品信息(用于DataGrid绑定)
        /// </summary>
        public DataTable Bind()
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("Goods");
            try
            {
                dt = db.GetDataTable(@"select a.GoodsId, a.GoodsName, a.Price, a.GoodsCategoryId,b.description GoodsCategoryDescription from Goods a,Goods_Category b where a.GoodsCategoryId = b.GoodsCategoryId");
                return dt;
            }
            catch
            {
                Common.ShowMsg("系统警告:查询商品信息失败!");
                return null;
            }
        }

        /// <summary>
        /// 根据商品ID查询该商品信息
        /// </summary>
        /// <param name="GoodsID">商品ID</param>
        /// <returns>返回商品数据表类</returns>
        public GoodsDB FindGoods(string GoodsID)
        {
            DBManager db = DBManager.Instance();	//通用数据操作类
            try
            {
                DataTable dt = new DataTable();
                dt = db.GetDataTable("select * from Goods where GoodsId='" + GoodsID + "'");
                GoodsDB goodsDB = new GoodsDB();
                if (dt.Rows.Count > 0)
                {
                    goodsDB.GoodsId = GoodsID;
                    goodsDB.Code = dt.Rows[0]["Code"].ToString().Trim();
                    goodsDB.Description = dt.Rows[0]["Description"].ToString().Trim();
                    goodsDB.GoodsCategoryId = dt.Rows[0]["GoodsCategoryId"].ToString().Trim();
                    goodsDB.GoodsName = dt.Rows[0]["GoodsName"].ToString().Trim();
                    goodsDB.Price = Convert.ToDouble(dt.Rows[0]["Price"].ToString().Trim());
                }
                return goodsDB;
            }
            catch (Exception exc)
            {
                Common.ShowMsg("系统警告：查询商品信息失败！");
                //Common.ErrLog(exc.ToString());
                return new GoodsDB();
            }
        }

        public bool AddGoods(string GoodsId, string GoodsName, string Code, double Price, string GoodsCateId, string Desc)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                string sql = db.GetValue("select COUNT(*) from Goods where Code='" + Code + "'").ToString();
                int count = int.Parse(sql);
                if (count == 0)
                {
                    int ReturnValue = -1;
                    db.Transact("insert into Goods values('" + GoodsId + "','" + GoodsName + "','" + Code + "','" + Price.ToString("0.00") + "','" + GoodsCateId + "','" + Desc + "')",
                        out ReturnValue);
                    if (ReturnValue <= 0) throw new Exception("新增商品数据出错!");
                    else
                        return true;
                }
                else
                {
                    Common.ShowMsg("系统警告：新增商品数据失败，此商品数据已经存在！");
                    return false;
                }
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：新增商品数据失败，可能此商品数据已经存在！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool UpdateGoods(string GoodsId,string GoodsName, double Price, string GoodsCate, string Desc)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("update Goods set Goodsname='" + GoodsName + "',Price='" + Price.ToString("0.00") + "',GoodsCategoryId='" + GoodsCate + "',Description='" + Desc + "' where GoodsId = '" + GoodsId + " '",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("更新商品数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：更新商品数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }

        public bool DelGoods(string GoodsId)
        {
            DBManager db = DBManager.Instance();//通用数据操作类
            try
            {
                int ReturnValue = -1;
                db.Transact("delete Goods where GoodsId = '" + GoodsId + " '",
                    out ReturnValue);
                if (ReturnValue <= 0) throw new Exception("删除商品数据出错!");
                else
                    return true;
            }
            catch//(Exception exc)
            {
                Common.ShowMsg("系统警告：删除商品数据信息失败！");
                //Common.ErrLog(exc.ToString());
                return false;
            }
        }
        /// <summary>
        /// 获取商品信息(用于DataGrid绑定)
        /// </summary>
        public DataTable BindNodes(string Id)
        {
            DBManager db = DBManager.Instance();
            DataTable dt = new DataTable("Goods");
            try
            {
                if (Id == "-1")
                {
                    dt = db.GetDataTable(@"select a.GoodsId, a.GoodsName, a.Price, a.GoodsCategoryId,b.description GoodsCategoryDescription from Goods a,Goods_Category b where a.GoodsCategoryId = b.GoodsCategoryId");
                }
                else
                {
                    dt = db.GetDataTable(@"with subqry(GoodsCategoryId,Description,FatherId) as (select GoodsCategoryId,Description,FatherId from Goods_Category where
GoodsCategoryId='" + Id + "' union all select Goods_Category.GoodsCategoryId,Goods_Category.Description, Goods_Category.FatherId from Goods_Category,subqry where Goods_Category.FatherId = subqry.GoodsCategoryId) select Goods.GoodsId,Goods.GoodsName,Goods.Price,Goods.GoodsCategoryId,subqry.Description GoodsCategoryDescription from subqry, Goods where Goods.GoodsCategoryId = subqry.GoodsCategoryId;");
                }
                return dt;
            }
            catch
            {
                Common.ShowMsg("系统警告:查询商品信息失败!");
                return null;
            }
        }
    }
}
