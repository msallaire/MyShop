using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductCatagoryManagerController : Controller
    {
        IRepository<ProductCatagory> context;

        public ProductCatagoryManagerController(IRepository<ProductCatagory> context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            List<ProductCatagory> productCatagories = context.Collection().ToList();
            return View(productCatagories);
        }

        public ActionResult Create()
        {
            ProductCatagory productCatagory = new ProductCatagory();
            return View(productCatagory);
        }
        [HttpPost]
        public ActionResult Create(ProductCatagory productCatagory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCatagory);
            }
            else
            {
                context.Insert(productCatagory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCatagory productCatagory = context.Find(Id);
            if (productCatagory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCatagory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCatagory productCatagory, string Id)
        {
            ProductCatagory productCatagoryToEdit = context.Find(Id);
            if (productCatagoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCatagoryToEdit);
                }
                productCatagoryToEdit.Id = productCatagory.Id;
                productCatagoryToEdit.Catagory = productCatagory.Catagory;

                context.Update(productCatagoryToEdit);
                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCatagory productCatagoryToDelete = context.Find(Id);
            if (productCatagoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCatagoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCatagory productCatagoryToDelete = context.Find(Id);
            if (productCatagoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}