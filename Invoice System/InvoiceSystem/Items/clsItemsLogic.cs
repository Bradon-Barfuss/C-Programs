using InvoiceSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Items
{
    class clsItemsLogic
    {
        /// <summary>
        /// My SQL class
        /// </summary>
        clsItemsSQL myItemsSQL;

        /// <summary>
        /// My Database class
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// get and return all items from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsItem> GetAllItems()
        {
            try { 
            myItemsSQL = new clsItemsSQL();
            db = new clsDataAccess();
            DataSet ds = new DataSet();
            int iRet = 0;

            List<clsItem> Items = new List<clsItem>();

            ds = db.ExecuteSQLStatement(myItemsSQL.GetAllItemsInformation(), ref iRet);

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                clsItem item = new clsItem();
                item.Code = (string)dr[0];
                item.Description = (string)dr[1];
                item.cost = (decimal)dr[2];
                Items.Add(item);
            }

            return Items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// add a item to the database
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <param name="description"></param>
        /// <exception cref="Exception"></exception>
        public void AddItem(string code, decimal cost, string description)
        {
            try { 
            myItemsSQL = new clsItemsSQL();
            db = new clsDataAccess();

            int pointlessWords = db.ExecuteNonQuery(myItemsSQL.AddItemToDataBase(code, cost, description));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// allows a user to edit the cost and description based on the item code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <param name="description"></param>
        /// <exception cref="Exception"></exception>
        public void EditItem(string code, decimal cost, string description)
        {
            try { 
            myItemsSQL = new clsItemsSQL();
            db = new clsDataAccess();

            int pointlessWords = db.ExecuteNonQuery(myItemsSQL.UpdateItemValuesIntoDB(code, cost, description));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// validate if a user entered a valid string
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool validateinput(string testString)
        {
            try { 
            if (testString == null)
            {
                return false;
            }
            return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// validate if a user entered a valid string
        /// </summary>
        /// <param name="testString1"></param>
        /// <param name="testString2"></param>
        /// <param name="testString3"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool validateinput(string testString1, string testString2, string testString3)
        {
            try { 
            if (testString1 == null || testString2 == null || testString3 == null || testString1 == "" || testString2 == "" || testString3 == "")
            {
                return false;
            }
            return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// check if an item is on a invoice's
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> CheckItemIsOnInvoice(string ItemCode)
        {
            try { 
            myItemsSQL = new clsItemsSQL();
            db = new clsDataAccess();
            int iRet = 0;
            DataSet ds = new DataSet();
            ds = db.ExecuteSQLStatement(myItemsSQL.GetItemsOnInvoice(ItemCode), ref iRet);

            List<clsInvoice> Items = new List<clsInvoice>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                clsInvoice item = new clsInvoice();
                item.InvoiceNum = (int)dr[0];
                Items.Add(item);
            }

            return Items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete an item from DB based on Itemcode
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteItem(string ItemCode)
        {
            try { 
            myItemsSQL = new clsItemsSQL();
            db = new clsDataAccess();

            int pointlessWords = db.ExecuteNonQuery(myItemsSQL.DeleteItemFromDataBase(ItemCode));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
