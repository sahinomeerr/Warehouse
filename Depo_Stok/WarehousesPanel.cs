using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depo_Stok
{
    internal class WarehousesPanel
    {
        public int warehouseNumber { get; set; } = 0;
        List<Warehouse> warehouseList = new List<Warehouse>();
        public void AddNewWarehouse()
        {
            Warehouse warehouse = new Warehouse();
            warehouseList.Add(warehouse);
            warehouseNumber++;
            Console.WriteLine("New warehouse is added. Current number of warehouses is : {0}", warehouseNumber);
        }
        public void ListWarehouses()
        {
            int i = 0;
            foreach (Warehouse item in warehouseList)
            {
                i++;
                Console.WriteLine(i + ". warehouse");
            }
        }
        public void ShipmentBetweenWarehouses()
        {
            ListWarehouses();
            Console.WriteLine("-------------------------");

            Console.Write("Please enter the warehouse you want to ship from : ");
            string shipmentFromInput = Console.ReadLine();
            bool isInputAnInt = int.TryParse(shipmentFromInput, out int shipmentFromInt);
            if (isInputAnInt && shipmentFromInt<warehouseNumber && shipmentFromInt > 0)
            {               
                Console.Write("Please enter the warehouse you want to ship to : ");
                string shipmentToInput = Console.ReadLine();
                bool isInputInt = int.TryParse(shipmentToInput, out int shipmentToInt);

                warehouseList[shipmentFromInt - 1].SeeProductsAmounts();

                Console.Write("Please enter the name of the product you want to ship : ");
                string productNameInput = Console.ReadLine();

                Console.Write("Please enter the number of products you want to ship : ");
                string productAmountInput = Console.ReadLine();
                bool isAmountInputInt = int.TryParse(productAmountInput, out int productAmountInt);

                if (isAmountInputInt && isInputInt && shipmentFromInt != shipmentToInt && warehouseList[shipmentFromInt - 1].CheckIfProductAlreadyExists(productNameInput) && warehouseList[shipmentFromInt - 1].CheckIfAmountIsEnough(productNameInput, productAmountInt)&& shipmentToInt < warehouseNumber && warehouseList[shipmentToInt - 1].CheckIfProductAlreadyExists(productNameInput))
                {
                    warehouseList[shipmentFromInt - 1].ChangeAmountOfProduct(productNameInput, productAmountInt, true);
                    warehouseList[shipmentToInt - 1].ChangeAmountOfProduct(productNameInput, productAmountInt, false);
                    Console.WriteLine("Shipment is completely done!");
                }
                else if (isAmountInputInt && isInputInt && shipmentFromInt != shipmentToInt && warehouseList[shipmentFromInt - 1].CheckIfProductAlreadyExists(productNameInput) && warehouseList[shipmentFromInt - 1].CheckIfAmountIsEnough(productNameInput, productAmountInt) && shipmentFromInt < warehouseNumber && shipmentToInt < warehouseNumber && !warehouseList[shipmentToInt - 1].CheckIfProductAlreadyExists(productNameInput))
                {
                    warehouseList[shipmentFromInt - 1].ChangeAmountOfProduct(productNameInput, productAmountInt, true);
                    warehouseList[shipmentToInt - 1].AddShipmentNewProduct(productNameInput,productAmountInt);
                    Console.WriteLine("Shipment is completely done!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have entered something wrong");
                    Console.WriteLine("--------------------------");
                    GoMainMenu();
                }
            }
            else
            {
                Console.WriteLine("This product does not exist");
            }
            
        }
        public void MainMenu()
        {
            Console.WriteLine("1)  Add new warehouse");
            Console.WriteLine("2)  List warehouses");
            Console.WriteLine("3)  List warehouses' products");
            Console.WriteLine("4)  Make a shipment");
            Console.WriteLine("5)  Add a new product");
            Console.Write("Please enter your choice : ");
            string inputOfUser = Console.ReadLine();
            switch (inputOfUser)
            {
                case "1":
                    AddNewWarehouse();
                    GoMainMenu();
                    break;
                case "2":
                    if (warehouseList.Count == 0) Console.WriteLine("There is no any warehouse yet");
                    else ListWarehouses();
                    GoMainMenu();
                    break;
                case "3":
                    if (warehouseList.Count == 0) Console.WriteLine("There is no any warehouse yet");
                    else
                    {
                        ListWarehouses();
                        Console.Write("Please enter the warehouse you want to check : ");
                        string warehouseInputUser = Console.ReadLine();
                        Console.WriteLine("");
                        bool isInputOfUserAnInt = int.TryParse(warehouseInputUser, out int warehouseInputUserInt);
                        if (isInputOfUserAnInt)
                        {
                            if (warehouseInputUserInt < warehouseNumber) warehouseList[warehouseInputUserInt].SeeProductsAmounts();
                            else Console.WriteLine("You have entered something wrong");
                        }
                        else Console.WriteLine("You have entered something wrong");
                    }
                    GoMainMenu();
                    break;
                case "4":
                    if (warehouseList.Count == 0) Console.WriteLine("There is no any warehouse yet");
                    else
                    {
                        ShipmentBetweenWarehouses();
                    }                    
                    GoMainMenu();
                    break;
                case "5":
                    if (warehouseList.Count == 0) Console.WriteLine("There is no any warehouse yet");
                    else
                    {
                        ListWarehouses();
                        Console.Write("Please enter the warehouse you want to add a product : ");
                        string newProductUserInput = Console.ReadLine();
                        bool isInputOfNewProductAnInt = int.TryParse(newProductUserInput, out int newProductUserInputInt);
                        if (isInputOfNewProductAnInt && newProductUserInput != null)
                        {
                            warehouseList[newProductUserInputInt].AddNewProduct();
                        }
                    }                 
                    GoMainMenu();
                    break;
                default:
                    Console.WriteLine("You have entered something wrong");
                    GoMainMenu();
                    break;

            }

        }
        public void GoMainMenu()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Press enter to go back to main menu");
            string a = Console.ReadLine();
            Console.Clear();
            MainMenu();
        }
    }
}
