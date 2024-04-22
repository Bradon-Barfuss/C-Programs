using InvoiceSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InvoiceSystem.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window {
        /// <summary>
        /// The item that is Selected and passed to Main
        /// </summary>
        public int selectedInvoiceNum { get; set; }
        /// <summary>
        /// bool to track visibillity
        /// </summary>
        private bool isShown = false;
        /// <summary>
        /// searchSQL objects
        /// </summary>
        private clsSearchSQL searchManager;
        /// <summary>
        /// searchLogic object
        /// </summary>
        private clsSearchLogic searchLogic;
        public wndSearch() {
            try {
                InitializeComponent();
                searchManager = new clsSearchSQL();
                searchLogic = new clsSearchLogic();
                RefreshGrid();
            }
            catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects an invoice Id and passes it to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e) {
            try {
                /// I plan on making selected invoice id a Search window property so it can be accessed by all windows
                this.Hide();
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// retunrs to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            try {
                e.Cancel = true;
                this.Hide();
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// refreshes the grid
        /// </summary>
        private void RefreshGrid() {
            try {
                cbInvoiceNum.ItemsSource = searchManager.GetDistinctInnvoices();
                cbInvoiceDate.ItemsSource = searchManager.GetDistinctDates();
                cbInvoiceCharge.ItemsSource = searchManager.GetDistinctCharges();
                dgInvoiceSearch.ItemsSource = searchManager.GetInvoices(searchLogic.getCurrItemString(cbInvoiceNum.SelectedItem),
                    searchLogic.getCurrItemString(cbInvoiceDate.SelectedItem), searchLogic.getCurrItemString(cbInvoiceCharge.SelectedItem));
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Refreshes window when visibillity is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Visibillity_Changed(object sender, DependencyPropertyChangedEventArgs e) {
            try {
                if (!isShown) {
                    RefreshGrid();
                    cbInvoiceNum.SelectedIndex = -1;
                    cbInvoiceDate.SelectedIndex = -1;
                    cbInvoiceCharge.SelectedIndex = -1;
                    isShown = true;
                }
                else {
                    isShown = false;
                }
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates the datagrid when ever a selection box is changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Search(object sender, EventArgs e) {
            try {
                RefreshGrid();
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// clears the search filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearFilter_Click(object sender, RoutedEventArgs e) {
            try {
                cbInvoiceNum.SelectedIndex = -1;
                cbInvoiceDate.SelectedIndex = -1;
                cbInvoiceCharge.SelectedIndex = -1;
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// changes the selected invoiceNumber when a row is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_Clicked(object sender, MouseButtonEventArgs e) {
            try {
                DataGridRow row = sender as DataGridRow;
                clsInvoice clickedInvoice = row.Item as clsInvoice;
                if (clickedInvoice != null) {
                    selectedInvoiceNum = clickedInvoice.InvoiceNum;
                }
                else {
                    selectedInvoiceNum = 0;
                }
            }
            catch (Exception ex) {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
