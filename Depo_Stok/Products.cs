using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depo_Stok
{
    internal class Products
    {
        public string nameProduct { get; set; }
        public int amountProduct { get; set; }
        public Products(string nameProduct,int amountProduct)
        {
            this.nameProduct = nameProduct;
            this.amountProduct = amountProduct;

        }
    }
}
