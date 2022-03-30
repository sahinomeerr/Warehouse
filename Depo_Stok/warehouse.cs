using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depo_Stok
{
    internal class Warehouse
    {
        List<Products> productList = new List<Products>();
        public Warehouse()
        {
        }
        public void AddNewProduct()
        {
            Console.Write("Please enter the product you want to add : ");
            string productInput = Console.ReadLine();
            while (true)
            {
                if (CheckIfProductAlreadyExists(productInput))
                {
                    Console.Clear();
                    Console.WriteLine("This product already exists");
                    Console.WriteLine("------------------------");
                    AddNewProduct();
                }
                else
                {
                    break;
                }
            }
            Console.Write("Please enter the amount of products you want to add : ");
            string productAmountInput = Console.ReadLine();
            bool isProductAmountAnInt = int.TryParse(productAmountInput, out int productAmountInt);
            if (isProductAmountAnInt)
            {
                if(productAmountInput != null && productAmountInt > 0)
                {
                    Products product = new Products(productInput, productAmountInt);
                    productList.Add(product);
                    Console.WriteLine("Now " + productAmountInt + " " + productInput + " are added.");
                }
                else
                {
                    Console.WriteLine("You have entered an invalid amount");
                }
            }

        }
        public bool CheckIfProductAlreadyExists(string productName)
        {
            foreach(Products item in productList)
            {
                if (productName.Equals(item.nameProduct))
                {
                    return true;
                }
            }
            return false;
        }
        public void SeeProductsAmounts()
        {
            int j = 0;
            foreach(Products item in productList)
            {
                j++;
                Console.WriteLine(j + ")  "+ item.nameProduct + " --> " + item.amountProduct);
            }
        }
        public bool CheckIfAmountIsEnough(string productNameShouldBeChecked,int productAmountShouldBeChecked)
        {
            foreach(Products item in productList)
            {
                if (item.nameProduct.Equals(productNameShouldBeChecked))
                {
                    if (productAmountShouldBeChecked < item.amountProduct)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void ChangeAmountOfProduct(string nameProductToBeDeducted,int amountToBeChanged,bool increaseOrDecrease)
        {
            foreach (Products item in productList)
            {               
                if (item.nameProduct.Equals(nameProductToBeDeducted))
                {
                    if (increaseOrDecrease) item.amountProduct += amountToBeChanged;
                    else item.amountProduct -= amountToBeChanged;
                }
            }
        }
        public void AddShipmentNewProduct(string nameProductShipped,int amountOfProductShipped)
        {
            if (amountOfProductShipped > 0)
            {
                Products product = new Products(nameProductShipped, amountOfProductShipped);
                productList.Add(product);
            }           
        }

    }
}
