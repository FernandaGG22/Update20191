using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC1.Models;
using SalesWebMVC1.Models.ViewModels;
using SalesWebMVC1.Services;
using SalesWebMVC1.Services.Exceptions;

namespace SalesWebMVC1.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;

        }

        //sincrono
        /*        public IActionResult Index()
                {
                    var list = _sellerService.FindAll();
                    return View(list);
                }
        */
        //assincrono
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        //sincrono
        /*        public IActionResult Create()
                {
                    var departments = _departmentService.FindAll();
                    var viewModel = new SellerFormViewModel { Departments = departments };
                    return View(viewModel);
                }
        */

        //assincrono
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        //sincrono
        /*        
                public IActionResult Create(Seller seller)
                {
                    if (!ModelState.IsValid)
                    {
                        var departments = _departmentService.FindAll();
                        var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                        return View(seller);
                    }
                    _sellerService.Insert(seller);
                    return RedirectToAction(nameof(Index));
                }
        */
        //assincrono
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(seller);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        //sincrono
        /*        public IActionResult Delete(int? id)
                {
                    if (id == null)
                    {
                        return RedirectToAction(nameof(Error), new { message = "Id not provided" });
                    }

                    var obj = _sellerService.FindById (id.Value);
                    if(obj == null)
                    {
                        return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
                    }
                    return View(obj);
                }
        */
        //assincrono
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //sincrono
        /*        public IActionResult Delete(int id)
                {
                    _sellerService.Remove(id);
                    return RedirectToAction(nameof(Index));
                }
        */
        //assincrono
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        //sincrono
        /*        public IActionResult Details(int? id)
                {
                    if (id == null)
                    {
                        return RedirectToAction(nameof(Error), new { message = "Id not provided" }); ;
                    }

                    var obj = _sellerService.FindById(id.Value);
                    if (obj == null)
                    {
                        return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
                    }
                    return View(obj);
                }
        */
        //assincrono
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" }); ;
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
            }
            return View(obj);
        }

        //sincrono
        /*       public IActionResult Edit(int? id)
               {
                   if  (id == null)
                   {
                       return RedirectToAction(nameof(Error), new { message = "Id not provided" }); ; 
                   }

                   var obj = _sellerService.FindById(id.Value);
                   if (obj == null)
                   {
                       return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
                   }

                   List<Department> departments = _departmentService.FindAll();
                   SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
                   return View(viewModel);
               }
       */
        //assincrono
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" }); ;
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;
            }

            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //sincrono
        /*       public IActionResult Edit(int id, Seller seller)
               {
                   if (!ModelState.IsValid)
                   {
                       var departments = _departmentService.FindAll();
                       var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                       return View(seller);
                   }

                   if (id != seller.Id)
                   {
                       return RedirectToAction(nameof(Error), new { message = "Id mismatch" }); 
                   }
                   try
                   {
                       _sellerService.Update(seller);
                       return RedirectToAction(nameof(Index));
                   }
                   catch (ApplicationException e)
                   {
                       return RedirectToAction(nameof(Error), new { message = e.Message }); ;
                   }
               }
       */
        //assincrono
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(seller);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); 
            }
        }


        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}