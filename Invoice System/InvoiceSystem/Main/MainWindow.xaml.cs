using InvoiceSystem.Common;
using InvoiceSystem.Items;
using InvoiceSystem.Search;
using Microsoft.VisualBasic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace InvoiceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        /// <summary>
        /// The page where you interact with the window
        /// </summary>
        wndSearch Search;

        /// <summary>
        /// The page where you interact with the window
        /// </summary>
        wndItems Item;

        /// <summary>
        /// Class where the logic is preformed
        /// </summary>
        clsMainLogic MainLogic;

        /// <summary>
        /// Class where the SQL is preformed
        /// </summary>
        clsMainSQL MainSQL;

        /// <summary>
        /// Data Access
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// True if editing
        /// </summary>
        bool Editing;

        /// <summary>
        /// rows in the table
        /// </summary>
        int rows;

        /// <summary>
        /// Total cost
        /// </summary>
        decimal total = 0;

        /// <summary>
        /// Current Invoice Number
        /// </summary>
        public int CurrentInvoice = 0;

        /// <summary>
        /// List of all items
        /// </summary>
        List<clsItem> items;

        /// <summary>
        /// Main window
        /// </summary>
        /// <exception cref="Exception"></exception>
        public MainWindow()
        {
            try
            {


                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Search = new wndSearch();
                Item = new wndItems();
                MainLogic = new();
                MainSQL = new();

                items = MainLogic.GetItemsInvoice(CurrentInvoice);
                dgInvoice.ItemsSource = items;
                UpdateItems();

                cbItems.ItemsSource = MainLogic.GetItemsData();
                dpInvoiceDate.SelectedDate = DateTime.Now;

                Editing = false;
                SetEnabled();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }


        /// <summary>
        /// Direct the User to the Search Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide the menu
                this.Hide();

                //Show the Search Window
                Search.ShowDialog();
                //Show main window after search is closed
                this.Show();
                CurrentInvoice = Search.selectedInvoiceNum;
                Editing = false;
                SetEnabled();
                if (CurrentInvoice == 0)
                {
                    lblInvoiceNum.Content = "TBD";

                }
                else
                {
                    lblInvoiceNum.Content = CurrentInvoice;
                    UpdateInvoiceCalendar();

                }
                items = MainLogic.GetItemsInvoice(CurrentInvoice);


                UpdateItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Direct the user to the Items Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                //Hide the menu
                this.Hide();

                //Show the Item Window
                Item.ShowDialog();

                if (Item.HasItemsChangedForMainWindow() == true)
                {
                    //cbItems.ItemsSource = MainLogic.GetItemsData();
                    items = MainLogic.GetItemsInvoice(CurrentInvoice);
                    UpdateItems();
                    //string SQL = MainSQL.SetInvoiceCost(Convert.ToInt32(total), CurrentInvoice); //if items cost are udpated in the items section, it will update it in the search window
                    //db.ExecuteNonQuery(SQL);
                }
                //Show main window after item is closed
                this.Show();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// When the button is clicked, update the enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Editing = true;
                SetEnabled();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// delete item from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = dgInvoice.SelectedIndex;

                if (x >= 0 && x < items.Count)
                {
                    items.RemoveAt(x);

                    UpdateItems();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


            /// <summary>
            /// Add items to the datagrid
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ItemSelected = cbItems.SelectedValue.ToString();
                db = new clsDataAccess();


                //Get cost
                string var = MainSQL.GetItemCost(ItemSelected);
                string cost = db.ExecuteScalarSQL(var);
                decimal d = decimal.Parse(cost);

                //Get code
                string x = MainSQL.GetItemCode(ItemSelected);
                string code = db.ExecuteScalarSQL(x);


                //TODO make function to get selected item from the database
                //Pass it into items.add
                items.Add(new clsItem(code, ItemSelected, Convert.ToDecimal(cost)));


                UpdateItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// error handeling
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// update the informaion needed for the new selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                

                db = new clsDataAccess();

                if (cbItems.SelectedIndex != -1)
                {
                    string ItemSelected = cbItems.SelectedValue.ToString();
                   string var = MainSQL.GetItemCost(ItemSelected);
                    lblCostS.Content = "$" + db.ExecuteScalarSQL(var);
                }



            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Set enabled
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void SetEnabled()
        {
            try
            {
                bool enabled = CurrentInvoice == 0 || Editing;



                cbItems.IsEnabled = enabled;
                btnAdd_Update.IsEnabled = enabled;
                btnDelete.IsEnabled = enabled;
                btnSave.IsEnabled = enabled;
                btnEditInvoice.IsEnabled = !enabled;
                btn_AddInvoice.IsEnabled = !enabled;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// add a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void btn_AddInvoice_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentInvoice = 0;
                lblInvoiceNum.Content = "TBD";
                items = MainLogic.GetItemsInvoice(CurrentInvoice);
                dgInvoice.ItemsSource = items;
                UpdateItems();


                Editing = true;
                SetEnabled();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// update the items in the dgInvoice
        /// </summary>
        private void UpdateItems()
        {
            try
            {
                //Force dgInvoice to refresh
                dgInvoice.ItemsSource = null;
                dgInvoice.ItemsSource = items;

                total = items.Sum(item => item.cost);
                lblTotalCostS.Content = "$" + total.ToString();


            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// update the calendar based on the invoice date selected
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void UpdateInvoiceCalendar()
        {
            try
            {

                db = new clsDataAccess();

                string SQL = MainSQL.selectInoviceDate(CurrentInvoice);
                string invoiceDate = db.ExecuteScalarSQL(SQL);
                dpInvoiceDate.SelectedDate = Convert.ToDateTime(invoiceDate);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// What to do when saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new clsDataAccess();
                string invoiceDate = dpInvoiceDate.Text;


                if (CurrentInvoice == 0)
                {
                    if (dpInvoiceDate.SelectedDate == null) //make sure the user has to select a date
                    {
                        MessageBox.Show("Please Enter a date");
                        return;
                    }
                    //insert a new invoice
                    string SQL = MainSQL.GetMaxInvoiceNum();
                    string MaxInvoiceNum = db.ExecuteScalarSQL(SQL);
                    int MaxInvoice = Convert.ToInt32(MaxInvoiceNum);
                    MaxInvoice = MaxInvoice + 1;
                    CurrentInvoice = MaxInvoice;
                    lblInvoiceNum.Content = MaxInvoice;
                    Search.selectedInvoiceNum = 0;
                    SQL = MainSQL.InsertNewInvoice(CurrentInvoice, invoiceDate, Convert.ToInt32(total));
                    db.ExecuteNonQuery(SQL);

                }
                else
                {
                    //Delete all from Line Items
                    string SQL = MainSQL.DeleteInvoice(CurrentInvoice);
                    db.ExecuteNonQuery(SQL);

                    //Update the invoice cost
                    SQL = MainSQL.SetInvoiceCost(Convert.ToInt32(total), CurrentInvoice);
                    db.ExecuteNonQuery(SQL);

                    //Get the needed information for inorder to insert int Line Items
                    int count = 1;
                    foreach (var item in dgInvoice.ItemsSource)
                    {
                        var CurrentItem = (clsItem)item;

                        var code = CurrentItem.Code;
                        var cost = CurrentItem.cost;
                        var description = CurrentItem.Description;


                        SQL = MainSQL.InsertItemToLineItems(CurrentInvoice, count, code);
                        db.ExecuteNonQuery(SQL);

                        count++;
                    }
                }
                //reset editing
                Editing = false;
                SetEnabled();

                //Clear all data
                CurrentInvoice = 0;
                lblInvoiceNum.Content = "TBD";
                dpInvoiceDate.Text = "Select Invoice Date";
                total = 0;
                lblTotalCostS.Content = "$00.00";
                lblCostS.Content = "$0";
                dgInvoice.ItemsSource = "";
                cbItems.SelectedIndex = -1;
                dpInvoiceDate.SelectedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}