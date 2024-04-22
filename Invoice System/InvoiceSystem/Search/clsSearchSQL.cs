using InvoiceSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace InvoiceSystem.Search {
    class clsSearchSQL {
        /// <summary>
        /// DataAccess class object
        /// </summary>
        private clsDataAccess dataAccess;
        /// <summary>
        /// DataSet object for storing query results
        /// </summary>
        private DataSet ds;
        /// <summary>
        /// A list of string used the methods will return 
        /// </summary>
        private List<string> retList;
        /// <summary>
        /// list of invoice objects
        /// </summary>
        private List<clsInvoice> invoices;
        /// <summary>
        /// list of item objects
        /// </summary>
        private List<clsItem> items;
        /// <summary>
        /// int value used to show how many record a query returned
        /// </summary>
        private int rows;
        /// <summary>
        /// boolena value to indicate which filters are being used on a given query
        /// </summary>
        private bool hasInvoiceNo, hasDate, hasTotalCost;

        /// <summary>
        /// Sql Querry to get all distinct invoice numbers
        /// </summary>
        /// <returns>query as a string</returns>
        /// <exception cref="Exception"></exception>
        private static string GetDistinctInnvoiceNumber() {
            try {
                string sQL = "SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum";
                return sQL;
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Sql Querry to get all distinct invoice dates
        /// </summary>
        /// <returns>query as a string</returns>
        /// <exception cref="Exception"></exception>
        private static string GetDistinctInnvoiceDates() {
            try {
                string sQL = "SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate";
                return sQL;
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Sql Querry to get all distinct invoice Total Costs
        /// </summary>
        /// <returns>query as a string</returns>
        /// <exception cref="Exception"></exception>
        private static string GetDistinctInnvoiceCharges() {
            try {
                string sQL = "SELECT DISTINCT(TotalCost) From Invoices order by TotalCost";
                return sQL;
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// executes GetDistinctInnvoicesNumber Query
        /// </summary>
        /// <returns>returns the Innvoice numbers as a list of strings</returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctInnvoices() {
            try {
                retList = new List<string>();
                dataAccess = new clsDataAccess();
                ds = dataAccess.ExecuteSQLStatement(GetDistinctInnvoiceNumber(), ref rows);

                for(int i = 0; i < rows; i++) {
                    retList.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                return retList;
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// executes GetDistinctInnvoiceDates Query
        /// </summary>
        /// <returns>returns the dates as a list of strings</returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctDates() {
            try {
                retList = new List<string>();
                dataAccess = new clsDataAccess();
                ds = dataAccess.ExecuteSQLStatement(GetDistinctInnvoiceDates(), ref rows);

                for (int i = 0; i < rows; i++) {
                    retList.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                return retList;
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// executes GetDistinctInnvoiceCharges Query
        /// </summary>
        /// <returns>returns the Total costs as a list of strings</returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctCharges() {
            try {
                retList = new List<string>();
                dataAccess = new clsDataAccess();
                ds = dataAccess.ExecuteSQLStatement(GetDistinctInnvoiceCharges(), ref rows);

                for (int i = 0; i < rows; i++) {
                    retList.Add(ds.Tables[0].Rows[i][0].ToString());
                }

                return retList;
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        

        /// <summary>
        /// Helper class to set the active filters
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="date"></param>
        /// <param name="totalCost"></param>
        private void filterCheck(string invoiceNo, string date, string totalCost) {
            try {
                hasInvoiceNo = hasDate = hasTotalCost = false;
                if (invoiceNo != "") { hasInvoiceNo = true; }
                if (date != "") { hasDate = true; }
                if (totalCost != "") { hasTotalCost = true; }
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// helper method to build the date part of the select
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string AddDateFilter(string date) {
            try {
                if (hasInvoiceNo) {
                    return " AND InvoiceDate = #" + date + "#";
                }
                else {
                    return "WHERE InvoiceDate = #" + date + "#";
                }
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// helper method to build the total cost part of the select
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string AddChargeFilter(string totalCost) {
            try {
                if (hasInvoiceNo || hasDate) {
                    return " AND TotalCost = " + totalCost;
                }
                else {
                    return "WHERE TotalCost = " + totalCost;
                }
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Dynamically creates and executes an SQL query depending on which information is provided
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="date"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> GetInvoices(string invoiceNo, string date, string totalCost){
            try {
                string sQL = "SELECT * FROM Invoices ";
                hasInvoiceNo = hasDate = hasTotalCost = false;
                invoices = new List<clsInvoice>();
                dataAccess = new clsDataAccess();
                //check which filters are active
                filterCheck(invoiceNo, date, totalCost);

                //Dynamically Create the sql Statement
                if(hasInvoiceNo) {sQL = sQL + "WHERE InvoiceNum = " + invoiceNo; }
                if(hasDate) { sQL = sQL + AddDateFilter(date); }
                if(hasTotalCost) { sQL = sQL + AddChargeFilter(totalCost); }

                //Execute the query
                ds = dataAccess.ExecuteSQLStatement(sQL, ref rows);

                for (int i = 0; i < rows; i++) {
                    clsInvoice temp = new clsInvoice();
                    temp.InvoiceNum = (int)ds.Tables[0].Rows[i][0];
                    temp.InvoiceDate = (DateTime)ds.Tables[0].Rows[i][1];
                    temp.TotalCost = (int)ds.Tables[0].Rows[i][2];
                    invoices.Add(temp);
                }

                return invoices;
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method used to handle errors
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sError"></param>
        /// <exception cref="Exception"></exception>
        private void HandleError(string sClass, string sMethod, string sError) {
            try {
                MessageBox.Show(sClass + "." + sMethod + " --> " + sError);
            }
            catch (Exception ex) {
                throw new Exception("Something has gone terribley wrong");
            }
        }
    }
}
