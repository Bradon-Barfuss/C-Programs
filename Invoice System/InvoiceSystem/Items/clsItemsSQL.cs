using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Items
{
    internal class clsItemsSQL
    {
        /// <summary>
        /// Get all the Items Codes, Items Description, and Costs from the ItemDesc Table
        /// </summary>
        public string GetAllItemsInformation()
        {
            try { 
            string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update the Item Description and cost of a item based of its item code value. It is unable to update the item code value
        /// It uses the 'where' statement based on the itemcodevalue
        /// </summary>
        /// <param name="ItemDescriptionValue"></param>
        /// <param name="ItemCostValue"></param>
        /// <param name="ItemCodeValue"></param>
        public string UpdateItemValuesIntoDB(string ItemCodeValue, decimal ItemCostValue, string ItemDescriptionValue) {
            try { 
            string sSQL = 
"UPDATE ItemDesc SET ItemDesc = '" + ItemDescriptionValue + "', Cost = " + ItemCostValue
                + " where ItemCode = '" + ItemCodeValue + "'";
            return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Add items to the data base by inserting the item code, cost, and description as params
        /// </summary>
        /// <param name="ItemCodeValue"></param>
        /// <param name="ItemCostValue"></param>
        /// <param name="ItemDescriptionValue"></param>
        public string AddItemToDataBase(string ItemCodeValue, decimal ItemCostValue, string ItemDescriptionValue)
        {
            try { 
            string sSQL = 
            "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) Values ('" + ItemCodeValue + "', '" + ItemDescriptionValue + "', " + ItemCostValue + ")";
            return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete a Item from the Database based on the Item Code provided in the parameters
        /// </summary>
        /// <param name="ItemCodeValue"></param>
        public string DeleteItemFromDataBase(string ItemCodeValue)
        {
            try { 
            string sSQL = "DELETE FROM ItemDesc WHERE ItemCode = '" + ItemCodeValue +"'";
            return sSQL;
                            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// get a speficic item from the database based on ItemCode
        /// </summary>
        /// <param name="ItemCodeValue"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetItemsOnInvoice(string ItemCodeValue)
        {
            try { 
            string sSQL = "SELECT InvoiceNum FROM LineItems WHERE ItemCode = '" + ItemCodeValue + "'";
            return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
    }
}
