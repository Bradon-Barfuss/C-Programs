using InvoiceSystem.Common;
using InvoiceSystem.Search;
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
using System.Xml.Linq;

namespace InvoiceSystem.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {

        bool ItemEditing = false;
        /// <summary>
        /// Class where the Item logic is preformed
        /// </summary>
        clsItemsLogic ItemsLogic;

        /// <summary>
        /// Class where the Items SQL is preformed
        /// </summary>
        clsItemsSQL ItemsSQL;

        /// <summary>
        /// Allows Main Window to know if items have been updated
        /// </summary>
        public bool bHasItemsChangedForMainWindow;

        /// <summary>
        /// Checks if Items have changed in the local class
        /// </summary>
        bool bHasItemsChanged;

        bool addItemOn;

        /// <summary>
        /// constructs the items windows
        /// </summary>
        public wndItems()
        {
            try
            {
                InitializeComponent();
                ItemsLogic = new clsItemsLogic();
                ItemsSQL = new clsItemsSQL();
                bHasItemsChangedForMainWindow = false;
                bHasItemsChanged = false;
                itemDataGrid.ItemsSource = ItemsLogic.GetAllItems(); //fill in the items in the datagrid window
                initlizeEnableSettings();
                addItemOn = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// update the status of an item being changed
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void UpdateItemChangedStatus()
        {
            try { 
            bHasItemsChangedForMainWindow = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// reset the item changed status for the main meny
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ResetItemChangedStatus()
        {
            try { 
            bHasItemsChangedForMainWindow = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// A function for the Main Window to use if the user has UPDATED any items from the items page
        /// </summary>
        /// <returns></returns>
        public bool HasItemsChangedForMainWindow()
        {
            try { 
            return bHasItemsChangedForMainWindow;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// When the Add Button is Clicked in the Item window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addItemOn = true;

                tbCode.IsReadOnly = false;
                tbCost.IsReadOnly = false;
                tbDescription.IsReadOnly = false;
                btnAdd_Item.IsEnabled = false;
                btnDelete_Item.IsEnabled = false;
                btnEdit_Item.IsEnabled = false;
                btnSave_Item.IsEnabled = true;


            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the user clicks the edit item button in the item windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Item_Click(object sender, RoutedEventArgs e)
        {
            try { 
            
                ItemEditing = true;
                EditItemSettingTurnOff();



            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            //allow the user to edit the cost and description of an item
        }

        /// <summary>
        /// when the item search window is turned on, these will be the default enable settings
        /// </summary>
        private void initlizeEnableSettings()
        {
            try
            {
                tbCode.IsReadOnly = true;
                tbCost.IsReadOnly = true;
                tbDescription.IsReadOnly = true;
                btnAdd_Item.IsEnabled = true;
                btnDelete_Item.IsEnabled = false;
                btnEdit_Item.IsEnabled = false;
                btnSave_Item.IsEnabled = false;

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }



        /// <summary>
        /// turn off text box editing
        /// </summary>
        private void turnOffTextbox()
        {
            try
            {
                tbCode.IsReadOnly = true;
                tbCost.IsReadOnly = true;
                tbDescription.IsReadOnly = true;

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// when the item grid button is pressed, these will be the default enable settings
        /// </summary>
        private void editDateGridTurnOn()
        {
            try { 
            btnEdit_Item.IsEnabled = true;
            btnDelete_Item.IsEnabled = true;
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// when the item edit button is turned off, these will be the default enable settings
        /// </summary>
        private void EditItemSettingTurnOff()
        {
            try
            {
                btnAdd_Item.IsEnabled = false;
                btnDelete_Item.IsEnabled = false;
                btnEdit_Item.IsEnabled = false;
                tbCost.IsReadOnly = false;
                tbDescription.IsReadOnly = false;
                btnSave_Item.IsEnabled = true;
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// when the item edit button is turned on, these will be the default enable settings
        /// </summary>
        private void EditItemSettingTurnOn()
        {
            try
            {
                btnAdd_Item.IsEnabled = true;
                btnDelete_Item.IsEnabled = true;
                btnEdit_Item.IsEnabled = true;
                btnSave_Item.IsEnabled = false;
                tbCost.IsReadOnly = false;
                tbDescription.IsReadOnly = false;
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// when the add item button is turned on, these will be the default enable settings
        /// </summary>
        private void addItemSettingTurnOn()
        {
            try
            {
                btnAdd_Item.IsEnabled = true;
                btnDelete_Item.IsEnabled = true;
                btnEdit_Item.IsEnabled = true;
                btnSave_Item.IsEnabled = false;
                tbCost.IsReadOnly = true;
                tbDescription.IsReadOnly = true;
                tbCode.IsReadOnly = true;
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


      

        /// <summary>
        /// When the user clicks the save item button in the item windows. it checks if the user
        /// has enter valided information then runs sql code to update it into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Item_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if(addItemOn == true)
                {
                    string TextBoxCode = tbCode.Text;
                    string TextBoxCost = tbCost.Text;
                    string TextBoxDescription = tbDescription.Text;

                    if (ItemsLogic.validateinput(TextBoxCode, TextBoxCost, TextBoxDescription) == true)
                    {
                        ItemsLogic = new clsItemsLogic();
                        ItemsLogic.AddItem(TextBoxCode, Decimal.Parse(TextBoxCost), TextBoxDescription);
                        itemDataGrid.ItemsSource = ItemsLogic.GetAllItems(); //fill in the items in the datagrid window
                        UpdateItemChangedStatus();
                        addItemOn = false;
                        addItemSettingTurnOn();
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid information");
                    }

                }
            else if(ItemEditing == true)
            {
                string TextBoxCode = tbCode.Text;
                string TextBoxCost = tbCost.Text;
                string TextBoxDescription = tbDescription.Text;
                ItemsLogic = new clsItemsLogic();

                if (ItemsLogic.validateinput(TextBoxCode, TextBoxCost, TextBoxDescription) == true)
                {
                    ItemsLogic = new clsItemsLogic();
                    ItemsLogic.EditItem(TextBoxCode, Decimal.Parse(TextBoxCost), TextBoxDescription);
                    itemDataGrid.ItemsSource = ItemsLogic.GetAllItems(); //fill in the items in the datagrid window
                    
                    UpdateItemChangedStatus();
                    EditItemSettingTurnOn();
                    turnOffTextbox();
                }
            }
               
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// When the user clicks the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Item_Click(object sender, RoutedEventArgs e)
        {
            try { 
            ItemsLogic = new clsItemsLogic();
            List<clsInvoice> items = ItemsLogic.CheckItemIsOnInvoice(tbCode.Text);

            if (items.Count == 0)
            {
                ItemsLogic.DeleteItem(tbCode.Text);
                UpdateItemChangedStatus();
                itemDataGrid.ItemsSource = ItemsLogic.GetAllItems(); //fill in the items in the datagrid window

                tbCode.Text = "";
                tbCost.Text = "";
                tbDescription.Text = "";

                btnEdit_Item.IsEnabled = false;
            }
            else
            {
                string InvoiceList = "";

                foreach (clsInvoice item in items)
                {
                    InvoiceList += item.InvoiceNum + " ";

                }
                MessageBox.Show("The item you selected is in Invoice(s): " + InvoiceList);
            }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Close the Item menu, in the main menu it opens the item menu with show dialog and when the item menu
        /// closes it appears again. so there is no need for open main menu from this function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try { 
            //hid the menu
            this.Hide();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
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
        /// When the user clicks the datagrid section of items window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridRow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try { 
            DataGridRow row = sender as DataGridRow;
            clsItem clickedItem = row.Item as clsItem;

            tbCode.Text = clickedItem.Code;
            tbCost.Text = clickedItem.cost.ToString();
            tbDescription.Text = clickedItem.Description;
            editDateGridTurnOn();

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// to make sure sure can only enter numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumberInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters and numbers to be entered
                if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter || e.Key == Key.OemPeriod || e.Key == Key.Decimal))
                    {
                        //No other keys allowed besides numbers, letters, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// enable input for only a-Z, 0-9, ' ', .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCharInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters and numbers to be entered
                if (!((e.Key >= Key.A && e.Key <= Key.Z || e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter || e.Key == Key.Space || e.Key == Key.OemPeriod || e.Key == Key.Decimal))
                    {
                        //No other keys allowed besides numbers, letters, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// enables A-z input, but no spaces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCharInputNoSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters and numbers to be entered
                if (!((e.Key >= Key.A && e.Key <= Key.Z)))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter))
                    {
                        //No other keys allowed besides numbers, letters, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
