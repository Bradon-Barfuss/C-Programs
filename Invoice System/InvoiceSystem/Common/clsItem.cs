using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Common
{
    class clsItem
    {
        /// <summary>
        /// The Code (PK) of the Item
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The Description of the Item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Cost of the Item
        /// </summary>
        public decimal cost { get; set; }

        public clsItem()
        {
        }

        public clsItem(string code, string description, decimal cost)
        {
            Code = code;
            Description = description;
            this.cost = cost;
        }
    }
}
