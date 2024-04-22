using InvoiceSystem.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace InvoiceSystem
{
    internal class clsMainSQL
    {
        /// <summary>
        /// data access class
        /// </summary>
        clsDataAccess db;



        /// <summary>
        /// Update the invoice in the database
        /// </summary>
        /// <param name="totalCost"></param>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string SetInvoiceCost(int totalCost, int invoiceNum)
        {
            try
            {

                string SQL = "UPDATE Invoices SET TotalCost =" + totalCost + " WHERE InvoiceNum = " + invoiceNum;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete Invoice from the database
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        public string DeleteInvoice(int InvoiceNumber) 
        {
            try
            {


                string SQL = "DELETE FROM LineItems WHERE InvoiceNum =" + InvoiceNumber;
                //This line is for debuging purposes
                    //string SQL = "DELETE FROM Invoices WHERE InvoiceNum =" + InvoiceNumber;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Insert a new Item in the invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="LineItem"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public string InsertItemToLineItems(int invoiceNum, int LineItem, string ItemCode)
        {
            try
            {
                string SQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values(" + invoiceNum + ", " + LineItem + ", '" + ItemCode + "')";
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Insert a new invoice to the database
        /// </summary>
        /// <param name="InvoiceDate"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        public string InsertNewInvoice(int InvoiceNum, string InvoiceDate, int totalCost)
        {
            try
            {


                string SQL = "INSERT INTO Invoices(InvoiceNum, InvoiceDate, TotalCost) Values(" + InvoiceNum + ", #" + InvoiceDate + "#, " + totalCost + ")";
                return SQL;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get max invoiceNum
        /// </summary>
        /// <returns>Max invoice Number</returns>
        public string GetMaxInvoiceNum()
        {
            try
            {

                string SQL = "SELECT MAX(InvoiceNum) FROM Invoices";
                return SQL;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Get all of the Items from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetAllItems()
        {
            try { 
            
                    string SQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
                    return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GEt Item description
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetAllItemsDESC()
        {
            try
            {

                string SQL = "SELECT ItemDesc FROM ItemDesc";
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the cost of the selected Item
        /// </summary>
        /// <param name="Item">ItemDEsc</param>
        /// <returns>cost</returns>
        /// <exception cref="Exception"></exception>
        public string GetItemCost(string Item)
        {
            try
            {
                db = new clsDataAccess();
                string SQL = "SELECT Cost FROM ItemDesc " +
                    "WHERE ItemDesc = \'" + Item + "\'";
                return SQL;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Get the code of the selected Item
        /// </summary>
        /// <param name="Item">ItemDEsc</param>
        /// <returns>code</returns>
        /// <exception cref="Exception"></exception>
        public string GetItemCode(string Item)
        {
            try
            {
                db = new clsDataAccess();
                string SQL = "SELECT ItemCode FROM ItemDesc " +
                    "WHERE ItemDesc = '" + Item + "'";
                return SQL;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        

        /// <summary>
        /// Get Invoice informaion
        /// </summary>
        private string select(int invoiceNum)
        {
            try
            {


                string SQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum =" + invoiceNum;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get Invoice date informaion
        /// </summary>
        public string selectInoviceDate(int invoiceNum)
        {
            try
            {

                string SQL = "SELECT InvoiceDate FROM Invoices WHERE InvoiceNum =" + invoiceNum;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Get the items on the invoice
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetItemsOnInvoice(int InvoiceNumber)
        {
            try
            {
                string SQL = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + InvoiceNumber;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        
    }
}
