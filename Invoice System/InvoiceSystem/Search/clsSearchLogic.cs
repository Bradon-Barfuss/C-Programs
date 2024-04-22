using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceSystem.Search {
    class clsSearchLogic {
        /// <summary>
        /// Gets the current item in the cb as a string
        /// </summary>
        /// <param name="invoiceCbItem"></param>
        /// <returns>returns the item as a string unless it is null then it returns an empty string</returns>
        /// <exception cref="Exception"></exception>
        public string getCurrItemString(object invoiceCbItem) {
            try {
                if(invoiceCbItem != null) {
                    return invoiceCbItem.ToString();
                }
                else {
                    return "";
                }
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
