using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
             IEnumerable<CoverType> coverTypeslist = _unitOfWork.CoverType.GetAll();
            return View(coverTypeslist);
        }


        // GET: Product/Edit/5
        public async Task<IActionResult> Upsert(int? id)
        {
            Product product = new();
            if (id == null || id == 0)
            {
                //if null save and create product
                return View(product);
            }
            else
            {
                //if not null update product

            }


            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
               
                    _unitOfWork.CoverType.Update(coverType);
                    _unitOfWork.Save();
                    TempData["success"] = "CoverType Edited Successfully";
                    return RedirectToAction("Index");
            }
            return View(coverType);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        // POST: Product/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType != null)
            {
                _unitOfWork.CoverType.Remove(coverType);
            }

            _unitOfWork.Save();
            TempData["success"] = "CoverType Deleted Successfully";
            return RedirectToAction("Index");
        }

        
    }
}
