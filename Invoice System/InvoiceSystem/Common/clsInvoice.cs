using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Common
{
    class clsInvoice
    {
        public int InvoiceNum { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int TotalCost { get; set; }

        public List<clsItem> listItems { get; set; }
        //Invoive Number
        //Invoice Date
        //Invoice Cost
        //List of Items
    }
}
