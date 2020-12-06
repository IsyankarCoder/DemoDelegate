using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DemoLibrary;

namespace WinFormUI {
    public partial class Form1 : Form {
        ShoppingCartModel cartModel = new ShoppingCartModel ();
        public Form1 () {
            InitializeComponent ();
            PopulateCartWithDemoData ();
        }
        private void button1_Click (object sender, EventArgs e) {
            decimal total = cartModel.GenerateTotal(SubTotalAlert,CalculateLevelDiscount,PrintOutDiscountAlert);
            MessageBox.Show($"The total is {total:C2}");
        }

        private void button2_Click (object sender, EventArgs e) {
            decimal total =  cartModel.GenerateTotal((subtotal)=>textBox1.Text= $"{subtotal:C2}",
                                                     (productList,subtotal)=>{
                                                            return subtotal-productList.Count *2;
                                                     },
                                                     (message)=>{});

          textBox2.Text = $"{total:C2}";
        }

        private void PrintOutDiscountAlert (string message) {
            MessageBox.Show (message);
        }

        private void SubTotalAlert(decimal subTotal){
            MessageBox.Show($"The subtotal is {subTotal:C2}");
        }

        private decimal CalculateLevelDiscount(List<ProductModel> products,decimal subTotal){
            return subTotal- products.Count();
        }
        private void PopulateCartWithDemoData () {
            cartModel.Item.Add (new ProductModel { ItemName = "Cereal", Price = 4.63M });
            cartModel.Item.Add (new ProductModel { ItemName = "Milk", Price = 2.95M });
            cartModel.Item.Add (new ProductModel { ItemName = "StrawBerries", Price = 7.51M });
            cartModel.Item.Add (new ProductModel { ItemName = "BlueBerries", Price = 8.11M });

        }

    }
}