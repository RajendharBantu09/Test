using System;
using System.Collections.Generic;
using DALShopBridge;
using ShopBridge.Model;
//using System.Web.Http;
namespace BLLShopeBridge
{
    public class BLInventory
    {
        public IEnumerable<Products> GetAllProducts()
        {
            DLInventory obj = new DLInventory();
          var objProductslist =  obj.GetAllProducts();
          return objProductslist;
        }

        public Products GetProduct(int id)
        {
            Products objProducts = new Products();
            DLInventory obj = new DLInventory();
            objProducts= obj.GetProduct(id);
            return objProducts;
        }
        //objBLInventory.PostNewProduct(objProducts);
        public long SaveNewProduct(Products objnewProduct)
        {
            long result = 0;
            DLInventory obj = new DLInventory();
            result = obj.SaveNewProduct(objnewProduct);
            return result;
        }


        public long DeleteProduct(long id)
        {
            long result = 0;
            DLInventory obj = new DLInventory();
            result = obj.DeleteProduct(id);
            return result;
        }



        public long UpdateProduct(Products objProducts)
        {
            long result = 0;
            //Products objProducts = new Products();
            DLInventory obj = new DLInventory();
            result = obj.UpdateProduct(objProducts);
            return result;
        }



    }
}
