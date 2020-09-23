using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShopeController : Controller
    {
        
        private readonly IShopeOperation _shopeOperation;
        public ShopeController(IShopeOperation shopeOperation)
        {
            _shopeOperation = shopeOperation;
           
        }
        public IActionResult ShopeList()
        {
            ShopeList model = new ShopeList();
            model.Shopes = _shopeOperation.GetAllShope();
            return View(model);

        }
        public IActionResult ShopeList2(string searchTrem)
        {
            ShopeList model = new ShopeList();
            model.Shopes = _shopeOperation.Search(searchTrem);
            return View(model);

        }

        public IActionResult Add()
        {
            ShopeFormVM model = new ShopeFormVM();
            model.Components = _shopeOperation.GetComponents(); 
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ShopeFormVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _shopeOperation.Create(model.Shope);
            return RedirectToAction(nameof(ShopeList));
        }

        
        

        public IActionResult Edit(int Id)
        {
            ShopeFormVM model = new ShopeFormVM();
            model.Shope = _shopeOperation.GetEditShope(Id);
            model.Components = _shopeOperation.GetComponents();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ShopeFormVM model)
        {
            model.Components = _shopeOperation.GetComponents();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _shopeOperation.Edit(model.Shope);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteShope(int Id)
        {
            _shopeOperation.Delete(Id);
            return RedirectToAction(nameof(ShopeList));
        }
    }
}