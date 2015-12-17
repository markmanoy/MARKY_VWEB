using Marky_VWeb.Models;
using PagedList;
using System;
using System.Web.Mvc;
namespace Marky_VWeb.Controllers
{
    /// <summary>
    /// Web Service Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class WebServiceController : Controller
    {
        ItemService.ItemServiceClient itemWS = new ItemService.ItemServiceClient();

        /// <summary>
        /// User Context
        /// </summary>
        private UsersContext db = new UsersContext();

        /// <summary>
        /// Gets the item list.
        /// </summary>
        /// <param name="searchName">Name of the search.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="currentFilter">The current filter.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public ActionResult Index(string searchName, string sortOrder, string currentFilter, int? page)
        {

            if (searchName != null)
            {
                page = 1;
            }
            else if (currentFilter != null)
            {
                searchName = currentFilter;
            }
            else
            {
                searchName = string.Empty;
            }

            ViewBag.CurrentFilter = searchName;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (!String.IsNullOrEmpty(searchName))
            {
                var searchItem = itemWS.GetItemList(searchName);
                var searhcount = searchItem.Length;
                return View(searchItem.ToPagedList(pageNumber, pageSize));
            }
            return View(itemWS.GetItemList(searchName).ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// GET: /WebService/Details/
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int id = 0)
        {
            var item = itemWS.GetItem(id);
            ItemInfo modalDetails = new ItemInfo();
            modalDetails.Name = item.Name;
            modalDetails.TypeId = item.TypeId;
            modalDetails.SubTypeId = item.SubTypeId;
            modalDetails.Manufacturer = item.Manufacturer;
            modalDetails.Cost = item.Cost;
            return PartialView("_AdditionalDetails", modalDetails);
        }


        /// <summary>
        /// GET: /WebService/Create
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("Create");
        }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="cost">The cost.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="subTypeId">The sub type identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string manufacturer, decimal cost, int typeId, int subTypeId)
        {
            bool added = itemWS.AddItem(name, manufacturer, typeId, subTypeId, cost);
            if (added)
            {
                TempData["Message"] = "*Item successfully added!";
            }
            else
            {
                TempData["Message"] = "*Failed to save Item.";
            }
            return RedirectToAction("Create");
        }

        /// <summary>
        /// GET: /WebService/Edit/5
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            var item = itemWS.GetItem(id);
            ItemInfo modalDetails = new ItemInfo();
            modalDetails.Name = item.Name;
            modalDetails.TypeId = item.TypeId;
            modalDetails.SubTypeId = item.SubTypeId;
            modalDetails.Manufacturer = item.Manufacturer;
            modalDetails.Cost = item.Cost;
            return PartialView("_EditDetails", modalDetails);
        }

        /// <summary>
        /// POST: /WebService/Edit/5
        /// Edits the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemInfo item)
        {
            itemWS.UpdateItem(item.Id, item.Name, item.Manufacturer, item.TypeId, item.SubTypeId, item.Cost);
            TempData["Message"] = "*Product successfully updated!";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET: /WebService/Delete/5
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            var item = itemWS.GetItem(id);
            ItemInfo modalDetails = new ItemInfo();
            modalDetails.Name = item.Name;
            modalDetails.TypeId = item.TypeId;
            modalDetails.SubTypeId = item.SubTypeId;
            modalDetails.Manufacturer = item.Manufacturer;
            modalDetails.Cost = item.Cost;
            return PartialView("_Delete", modalDetails);
        }

        /// <summary>
        /// POST: /WebService/Delete/
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itemWS.DeleteItem(id);
            TempData["Message"] = "*Item successfully deleted!";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Item Information
        /// </summary>
        public class ItemInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Manufacturer { get; set; }
            public decimal Cost { get; set; }
            public int TypeId { get; set; }
            public int SubTypeId { get; set; }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
