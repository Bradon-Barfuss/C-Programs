using InvoiceSystem.Common;
using InvoiceSystem.Items;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InvoiceSystem
{
    internal class clsMainLogic
    {
        /// <summary>
        /// true if the invoice is being edited
        /// </summary>
        public bool invoiceBeingEdited;

        /// <summary>
        /// Class with SQL
        /// </summary>
        clsMainSQL MainSQL;

        /// <summary>
        /// data access class
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// Main Window class
        /// </summary>
        MainWindow MainClass;


        /// <summary>
        /// DataSet object for storing query results
        /// </summary>
        private DataSet ds;
        /// <summary>
        /// how many rows to return
        /// </summary>
        private int rows;
        /// <summary>
        /// A list of string the method will return 
        /// </summary>
        private List<string> retList;


        /// <summary>
        /// executes GetAllItems Query
        /// </summary>
        /// <returns>returns the Total costs as a list of strings</returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetItemsData()
        {
            try
            {
                MainSQL = new clsMainSQL();
                retList = new List<string>();
                db = new clsDataAccess();
                ds = db.ExecuteSQLStatement(MainSQL.GetAllItemsDESC(), ref rows);

                for (int i = 0; i < rows; i++)
                {
                    retList.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                return retList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the items on the invoice
        /// </summary>
        /// <param name="InvoiceNum">Invoice number</param>
        /// <returns>Items</returns>
        /// <exception cref="Exception"></exception>
        public List<clsItem> GetItemsInvoice(int InvoiceNum)
        {
            try
            {


                MainSQL = new clsMainSQL();
                db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;

                List<clsItem> Items = new List<clsItem>();

                //TODO Ask Andrew why this is not working
                ds = db.ExecuteSQLStatement(MainSQL.GetItemsOnInvoice(InvoiceNum), ref iRet);
                //ds = db.ExecuteSQLStatement(MainSQL.GetAllItems(), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
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



    }
}
