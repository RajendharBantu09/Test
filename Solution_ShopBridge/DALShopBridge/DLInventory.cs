using System;
using System.Collections.Generic;
using System.Linq;
using DALShopBridge.Entities;
using ShopBridge.Model;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Threading.Tasks;
//using System.Web.Http;


namespace DALShopBridge
{
    public class DLInventory
    {
        public  List<Products> GetAllProducts()
        {
            try
            {
                List<Products> objProducts = new List<Products>();
                var objentities = new dbShopBridgeEntities();
                var objProductslist = objentities.ShopInventories.ToList();
                foreach (var item in objProductslist)
                {
                    objProducts.Add(new Products()
                    {
                        ID = item.ID,
                        ItemType = item.ItemType,
                        ItemName = item.ItemName,
                        Price = Convert.ToDecimal(item.Price),
                        Description = item.Description,
                        Quantity=Convert.ToInt64(item.Quantity)
                    });

                }
                return objProducts;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public Products GetProduct(long id)
        {
            try { 
            Products objProducts = new Products();
            var objentities = new dbShopBridgeEntities();
           var obj= objentities.ShopInventories.Where(x => x.ID == id).FirstOrDefault();
            if (obj != null) { 
            objProducts.ID = obj.ID;
            objProducts.ItemType = obj.ItemType;
            objProducts.ItemName = obj.ItemName;
            objProducts.Price =Convert.ToDecimal(obj.Price);
            objProducts.Description = obj.Description;
            objProducts.Quantity =Convert.ToInt64(obj.Quantity);
                }
            return objProducts;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

      

        public long SaveNewProduct(Products objnewProduct)
        {
            long result = 0;
            try
            {
                Products objProducts = new Products();
                using (var ctx = new dbShopBridgeEntities())
                {
                    if (objnewProduct != null)
                    {
                        ctx.ShopInventories.AddObject(new ShopInventory()
                        {
                            ItemType = objnewProduct.ItemType,
                            ItemName = objnewProduct.ItemName,
                            Price = objnewProduct.Price,
                            Description = objnewProduct.Description,
                            CreatedBy = objnewProduct.CreatedBy,
                            Quantity = objnewProduct.Quantity,
                            CreatedDate = DateTime.Now

                        }) ;
                      result=ctx.SaveChanges();
                        //result= objShopInventory.ID;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

       

        public long DeleteProduct(long  id)
        {
            long result = 0;
            try
            {
                Products objProducts = new Products();
                using (var ctx = new dbShopBridgeEntities())
                {
                    var obj = ctx.ShopInventories
                        .Where(s => s.ID == id)
                        .FirstOrDefault();
                    ctx.ShopInventories.DeleteObject(obj);
                    ctx.SaveChanges();

                    result = 1;
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public long UpdateProduct(Products objProducts)
        {
            long result = 0;
            try
            {

            using (var ctx = new dbShopBridgeEntities())
            {
                var objprod = ctx.ShopInventories
                    .Where(s => s.ID == objProducts.ID)
                    .FirstOrDefault();
                if (objprod != null)
                {
                    objprod.ItemType = objProducts.ItemType;
                    objprod.ItemName = objProducts.ItemName;
                    objprod.Price = objProducts.Price;
                    objprod.Description = objProducts.Description;
                    objprod.Quantity =Convert.ToInt64(objProducts.Quantity);
                    objprod.ModifiedDate = DateTime.Now;
                    objprod.ModifiedBy = objProducts.ModifiedBy;
                    ctx.SaveChanges();
                  result = 1;
                }
            }
            return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }

    }
}
