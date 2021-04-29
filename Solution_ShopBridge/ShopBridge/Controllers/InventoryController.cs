using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBridge.Model;
using BLLShopeBridge;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShopBridge.Controllers
{
    //[Produces("application/json")]
    [Route("api/Inventory")]
    public class InventoryController : ApiController
    {
        public InventoryController()
        {

        }



        [Route("~/api/GetAllProducts")]
        [HttpGet]
        public  IEnumerable<Products> GetAllProducts()
        {
            //List<Products> objProductsList = new List<Products>();
            try
            {
                BLInventory objBLInventory = new BLInventory();
              var   objProductsList = objBLInventory.GetAllProducts();
                return objProductsList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        [Route("~/api/GetProduct/{id}")]
        //[Route("~/api/GetProduct")]
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            try
            {
                Products objproducts = new Products();
                BLInventory objBLInventory = new BLInventory();
                objproducts = objBLInventory.GetProduct(id);

                if (objproducts == null)
                {
                    return NotFound();
                }
                else { 
                return Ok(objproducts);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("~/api/PostNewProduct")]
        [HttpPost]
        public IHttpActionResult PostNewProduct(Products objProducts)
        {
            string resp = string.Empty;
            try { 
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            Products objproducts = new Products();
            BLInventory objBLInventory = new BLInventory();
            var objresult = objBLInventory.SaveNewProduct(objProducts);
            if(objresult>0)
            {
                resp = "{\"status\":\"SUCCESS\",\"data\":\"Item has been added successfully\"}";  // TEST !!!!!           
            }
            else
            {
                resp = "{\"status\":\"FAIL\"}";  // TEST !!!!!    
            }
                return Ok(JsonConvert.SerializeObject(resp));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }




        [Route("~/api/Putproduct")]
        [HttpPut]
        public IHttpActionResult Putproduct(Products objProducts)
        {
            string resp = string.Empty;
            long result = 0;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                Products objproducts = new Products();
                BLInventory objBLInventory = new BLInventory();
                result = objBLInventory.UpdateProduct(objProducts);
                if (result > 0)
                {
                    resp = "{\"status\":\"SUCCESS\",\"data\":\"Item has been updated successfully\"}";  // TEST !!!!!           
                }
                else
                {
                    resp = "{\"status\":\"FAIL\"}";  // TEST !!!!!    
                }
                return Ok(JsonConvert.SerializeObject(resp));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Route("~/api/DeleteProduct/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            string resp = string.Empty;
            if (id <= 0)
                return BadRequest("Not a valid product id");
            
            BLInventory objBLInventory = new BLInventory();
            var objresult = objBLInventory.DeleteProduct(id);
            if (objresult > 0)
            {
                resp = "{\"status\":\"SUCCESS\",\"data\":\"Item has been deleted successfully\"}";  // TEST !!!!!           
            }
            else
            {
                resp = "{\"status\":\"FAIL\"}";  // TEST !!!!!    
            }
            
            return Ok(JsonConvert.SerializeObject(resp));
        }

    }
}
