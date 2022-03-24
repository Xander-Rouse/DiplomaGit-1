using System;
using System.Collections.Generic;
using System.Linq;

namespace DipGitApiLib {
    public class Product {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
    }

    public class Products {
        public List<Product> ProductList { get; set; }

        /// <summary>
        /// Sums the qty of all items in ProductList together
        /// </summary>
        /// <returns></returns>
        public int GetTotalQtyProducts() {
            int RunningTotal = 0;
                foreach (Product in ProductList) {
                    RunningTotal = RunningTotal + Qty;
                }
                return RunningTotal;
            ///throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the total cost of inventory, that is the sum of the cost of all items 
        /// </summary>
        /// <returns></returns>
        public int GetTotalValueProducts() {
            int RunningTotal = 0;
            foreach (Product in ProductList) {
                RunningTotal = (Qty * Price) + RunningTotal;
            }
            return RunningTotal;
            ///throw new NotImplementedException();
        }
    }
}
