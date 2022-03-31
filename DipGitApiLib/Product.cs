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
        public int GetTotalQtyProducts(int Qty) {
            int RunningTotal = 0;
                for(int i = 0; i < ProductList.Count; i++) {
                    RunningTotal = RunningTotal + Qty;
                }
                return RunningTotal;
            ///throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the total cost of inventory, that is the sum of the cost of all items 
        /// </summary>
        /// <returns></returns>
        public int GetTotalValueProducts(int Qty, int Price) {

            int RunningTotal = 0;
            for(int i = 0; i < ProductList.Count; i++) {
                RunningTotal = (Qty * Price) + RunningTotal;
            }
            return RunningTotal;
            ///throw new NotImplementedException();
        }
    }
}
