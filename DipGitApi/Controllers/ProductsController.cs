using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Microsoft.Extensions.Configuration;
using DipGitApiLib;
using System.Text.Json;
using System.Net;
using System.Linq;

namespace DipGitApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase

    {
        static Products products = new Products();
        private readonly IConfiguration _config;
        private RestClient _client;
        private string _accessKey;

        public ProductsController(IConfiguration config) {
            _config = config;
            _client = new RestClient(_config.GetConnectionString("RestDB_Url"));
            _accessKey = _config.GetConnectionString("key");
        }
   
        /// <summary>
        /// Searches Products for the value of a specific field
        /// </summary>
        /// <param name="field">Name of field to search on</param>
        /// <param name="value">value of field</param>
        /// <returns>Object if found</returns>
        [HttpGet("{field}/{value}")]
        public async Task<IActionResult> SearchProduct(string field, string value) {
            string search = $"{{\"{field}\":\"{value}\"}}";

            var request = new RestRequest();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", _accessKey);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter("q", search);
            var response = await _client.GetAsync(request);

            if(response.Content.Contains("_id")) {
                return Ok(response.Content);
            }

            return NotFound();
        }

        /// <summary>
        /// Gets all Products and returns them
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            // return all item as a Products object
            var request = new RestRequest();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", _accessKey);
            request.AddHeader("content-type", "application/json");
            var response = await _client.GetAsync(request);

            // TODO set condition
            if(response.Content.Contains("_id")) {
                return Ok(response.Content);
                // TODO cast as products object
            }

            return NotFound();
        }

        /*

        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Product newProduct) {
            // var testNewProduct = new Product();
            // testNewProduct.Name = "Big Donut";
            // testNewProduct.Price = 10F;
            // testNewProduct.Qty = 10;

            var newProductAltered = JsonSerializer.Serialize(newProduct);

            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", _accessKey);
            // request.AddJsonBody(newProductAltered);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", newProductAltered, ParameterType.RequestBody);
            Console.WriteLine(request.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault());
            var paramsList = request.Parameters.Where(p => p.Type == ParameterType.HttpHeader).ToArray();
            for(var i =0; i<paramsList.Length;i++){
                Console.WriteLine(paramsList[i].ToString());
            }
            var response = await _client.ExecuteAsync(request);

            if(response.IsSuccessful){
            return Ok(response.Content);
            // if (response.StatusCode == HttpStatusCode.OK){
            // }
            } else{
                return Problem(response.Content);
            }

        }


        /// <summary>
        /// Deletes a product based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string id) {
            var request = new RestRequest("", Method.Delete);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", _accessKey);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", $"{{\"id\":\"{id}\"}}", ParameterType.RequestBody);
            var response = await _client.DeleteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK){
                return Ok(response.Content);
            }

            return NotFound();
        }


        /// <summary>
        /// Returns the total qty of item from all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTotalQty")]
        public async Task<IActionResult> GetTotalQty() {
            // Read all products and create a Products object.  Use the products object to determine the total qty
            
            // TODO set condition does this work
            // products = GetAll();

            // return products.GetTotalQtyProducts();
            return BadRequest();
        }


        /// <summary>
        /// Returns the total value of all item prices summed.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTotalValue")]
        public async Task<IActionResult> GetTotalValue() {
            // Read all products and create a Products object.  Use the products object to determine the total value
            // products = GetAll();

            // return products.GetTotalValueProducts();

            return BadRequest();
        }
        */
    }
}