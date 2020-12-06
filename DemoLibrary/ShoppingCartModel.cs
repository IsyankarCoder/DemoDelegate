using System;
using System.Collections.Generic;
using System.Linq;
namespace DemoLibrary {
    public class ShoppingCartModel {
        
        public delegate void MentionDiscount(decimal subTotal);
        public List<ProductModel> Item { get; set; } = new List<ProductModel> ();

        public decimal GenerateTotal (MentionDiscount mentionDiscount,
                                     Func<List<ProductModel>,decimal,decimal> CalculatedDiscountPrice,
                                     Action<string> tellUsWeAreDiscounting) {
            decimal subTotal = Item.Sum (d => d.Price);
            mentionDiscount(subTotal);
            tellUsWeAreDiscounting("We are applying your discount");
            return CalculatedDiscountPrice(Item,subTotal);
            }
    }
}