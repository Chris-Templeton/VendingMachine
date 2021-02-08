using System;
using System.Collections.Generic;
using System.Text;
using Capstone;
using Capstone.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(45)]
        [DataRow(2.89)]
        public void ConstructorTests(double balance)
        {
            decimal balanceM = (decimal)balance;
            VendingMachine vm = new VendingMachine(balanceM);
            Assert.AreEqual(balanceM, vm.Balance);
            Assert.IsNotNull(vm.Inventory);
            Assert.AreEqual(0, vm.Inventory.Count);
        }
        [TestMethod]
        public void AddItemTest()
        {
            VendingMachine vm = new VendingMachine(0);
            vm.AddItem("A1|Potato Crisps|3.05|Chip");
            Assert.AreEqual(1, vm.Inventory.Count);
            CollectionAssert.Contains(vm.Inventory.Keys, "A1");
            Assert.IsInstanceOfType(vm.Inventory["A1"], typeof(Chip));

            vm.AddItem("B1|Moonpie|1.80|Candy");
            Assert.AreEqual(2, vm.Inventory.Count);
            CollectionAssert.Contains(vm.Inventory.Keys, "B1");
            Assert.IsInstanceOfType(vm.Inventory["B1"], typeof(Candy));

            vm.AddItem("C1|Cola|1.25|Drink");
            Assert.AreEqual(3, vm.Inventory.Count);
            CollectionAssert.Contains(vm.Inventory.Keys, "C1");
            Assert.IsInstanceOfType(vm.Inventory["C1"], typeof(Drink));


            vm.AddItem("D1|U-Chews|0.85|Gum");
            Assert.AreEqual(4, vm.Inventory.Count);
            CollectionAssert.Contains(vm.Inventory.Keys, "D1");
            Assert.IsInstanceOfType(vm.Inventory["D1"], typeof(Gum));
        }

        [TestMethod]
        public void GetInventoryTest()
        {
            VendingMachine vm = new VendingMachine(0);
            vm.AddItem("A1|Potato Crisps|3.05|Chip");
            vm.AddItem("C4|Heavy|1.50|Drink");
            string actual = vm.GetInventory();
            string expected= String.Format("A1. {0,-18}  {2,-6}  {1,-6}\n", "Potato Crisps", $"(QTY: 5)", "$3.05");
            expected+= String.Format("C4. {0,-18}  {2,-6}  {1,-6}\n", "Heavy", $"(QTY: 5)", "$1.50");
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ContainsTest()
        {
            VendingMachine vm = new VendingMachine(0);
            vm.AddItem("A1|Potato Crisps|3.05|Chip");
            Assert.IsTrue(vm.Contains("A1"));
            Assert.IsFalse(vm.Contains("B2"));
        }
        [TestMethod]
        public void IsNotSoldOutTest()
        {
            VendingMachine vm = new VendingMachine(0);
            vm.AddItem("A1|Potato Crisps|3.05|Chip");
            vm.AddItem("C4|Heavy|1.50|Drink");
            vm.Inventory["C4"].Quantity = 0;
            Assert.IsTrue(vm.IsNotSoldOut("A1"));
            Assert.IsFalse(vm.IsNotSoldOut("C4"));
        }
        [TestMethod]
        public void CanBuyTest()
        {
            VendingMachine vm = new VendingMachine(2);
            vm.AddItem("A1|Potato Crisps|3.05|Chip");
            vm.AddItem("C4|Heavy|1.50|Drink");
            Assert.IsTrue(vm.CanBuy("C4"));
            Assert.IsFalse(vm.CanBuy("A1"));
        }
        [DataTestMethod]
        [DataRow(0, "Dispensed Change Quarters:0 Dimes:0 Nickels:0 Pennies:0")]
        [DataRow(.25, "Dispensed Change Quarters:1 Dimes:0 Nickels:0 Pennies:0")]
        [DataRow(.95, "Dispensed Change Quarters:3 Dimes:2 Nickels:0 Pennies:0")]
        [DataRow(1.57, "Dispensed Change Quarters:6 Dimes:0 Nickels:1 Pennies:2")]
        public void DispenseChangeTest(double balance,string expected)
        {
            decimal balanceM = (decimal)balance;
            VendingMachine vm = new VendingMachine(balanceM);
            string actual = vm.DispenseChange();
            Assert.AreEqual(0M,vm.Balance);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GenerateReportTest()
        {
            VendingMachine vm = new VendingMachine(0);
            vm.AddItem("A1|Potato Crisps|3.05|Chip");
            vm.Inventory["A1"].Quantity = 3;
            string actual = vm.GenerateReport();
            string expected = "Potato Crisps|2\n\n$6.10";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PurchaseTest()
        {
            VendingMachine vm = new VendingMachine(10);
            vm.AddItem("A1|Potato Crisps|3.05|Chip");
            vm.Purchase("A1");
            Assert.AreEqual(6.95M, vm.Balance);
            Assert.AreEqual(4, vm.Inventory["A1"].Quantity);
        }
    }
}
