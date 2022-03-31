using System;
using Xunit;
using DipGitApiLib;
using System.Collections.Generic;

namespace DipGitApiTests
{
    
    public class UnitTest1
    {
        /*
        [Fact]
        public void TestTotalQty()
        {
            var products = new Products();

            int value1 = 1;
            int value2 = 2;

            var result = products.GetTotalQtyProducts(value1);
            var result2 = products.GetTotalQtyProducts(value2);
            var result3 = result + result2;

            Assert.Equal(3, result3);
        }
        */
        
        [Theory]
        [InlineData(4,8,12)]
        [InlineData(-5,5,0)]
        [InlineData(0,0,0)]
        public void GetTotalQtyTest(int val1, int val2, int expected)
        {
            var products = new Products();
            products.ProductList = new List<Product>();
            products.ProductList.Add(new Product {Qty = val1});
            products.ProductList.Add(new Product {Qty = val2});
            var result = products.GetTotalQtyProducts();

            Assert.Equal(expected, result);
        
        }

        [Theory]
        [InlineData(4,8,16)]
        [InlineData(1.5f,5,8f)]
        [InlineData(0,0,0)]
        public void GetTotalPriceTest(float val1, float val2, float expected)
        {
            var products = new Products();
            products.ProductList = new List<Product>();
            products.ProductList.Add(new Product {Price = val1, Qty = 2});
            products.ProductList.Add(new Product {Price = val2, Qty = 1});
            var result = products.GetTotalValueProducts();

            Assert.Equal(expected, result);
        
        }
        
    }
}
