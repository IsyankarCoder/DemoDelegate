using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using DemoLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI {
    class Program {
       //  delegate void  myDelegate(decimal sub);
        static ShoppingCartModel cart = new ShoppingCartModel ();

        static void Main (string[] args) {
            PopulateCartWithDemoData ();

             

            DemoLibrary.ShoppingCartModel.MentionDiscount del =  SubTotalAlert;
            del+=SubTotalAlert2;

            Console.WriteLine ($"The total for the card is  {cart.GenerateTotal(del,CalculateLeveledDiscount,PriceDiscount):C2}");
            Console.WriteLine ();
            
            decimal total = cart.GenerateTotal((subTotal)=>{ Console.WriteLine($"The subtotal cart 55 is {subTotal:c2}");},
                                               (products,subtotal)=>{
                                                    if(products.Count>2)
                                                    return subtotal*0.5M;
                                                    else
                                                    return subtotal;

                                               },
                                               (message)=>{Console.WriteLine($"Cart2  Alert : {message}");}
            );
            
            
            Console.WriteLine($"The total for the cart2 {total:C2}");
            
            Console.Write ("Please Press Any Key To Exist .....");
            Console.ReadKey (); 
        }

        private static void SubTotalAlert (decimal subTotal) {
            Console.WriteLine ($"The sub Total is {subTotal:c2}");
        }

        private static void SubTotalAlert2 (decimal subTotal) {
            Console.WriteLine ($"The subTotal is alert 2 {subTotal:c2}");
        }

        private static void PriceDiscount(string message){
            Console.WriteLine(message);
        }

        private  static decimal CalculateLeveledDiscount(List<ProductModel> items,decimal subTotal){
            if (subTotal > 100) {
                return subTotal * 0.80M;
            } else if (subTotal > 50) {
                return subTotal * 0.5M;
            } else if (subTotal > 10)
                return subTotal * 0.95M;
            else
                return subTotal;
        }
        private static void PopulateCartWithDemoData () {
            cart.Item.Add (new ProductModel () { ItemName = "Cereal", Price = 3.63M });
            cart.Item.Add (new ProductModel () { ItemName = "Milk", Price = 2.93M });
            cart.Item.Add (new ProductModel () { ItemName = "StrawBerries", Price = 7.51M });
        }
    }

}