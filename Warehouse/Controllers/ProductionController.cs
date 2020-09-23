using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO.Production;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductionController : Controller
    {
        
        private readonly IProductionOperation productionOperation;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProductionController(IProductionOperation productionOperation,IWebHostEnvironment hostEnvironment)
        {
            _hostingEnvironment = hostEnvironment;
            this.productionOperation = productionOperation;
        }
        public IActionResult ProductionList(string SearchTerm)
        {
            ProductionList model = new ProductionList();
            
            model.Productions = productionOperation.GetAllProduction(SearchTerm);

            return View(model);
        }

        public IActionResult Add()
        {
            ProductionFormVM model = new ProductionFormVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ProductionFormVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Production.Image = UploadFile(model.Production.File);
            productionOperation.Create(model.Production);
            return RedirectToAction(nameof(ProductionList));
        }

        public IActionResult Edit(int Id)
        {
            ProductionFormVM model = new ProductionFormVM();
            model.Production = productionOperation.GetEditProduction(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductionFormVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string Thumb = UploadFile(model.Production.File);
            model.Production.Image = string.IsNullOrEmpty(Thumb) ? model.Production.Image : Thumb;
            productionOperation.Edit(model.Production);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteProduction(int Id)
        {
            productionOperation.Delete(Id);
            return RedirectToAction(nameof(ProductionList));
        }

        private string GenerateFileDirectoryName()
        {
            return $"{DateTime.Now.Year}/{DateTime.Now.Month}/";
        }
        
        private void CheckAndCreateDirectory(string path)
        {
           bool exists = Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, path));

            if (!exists)
            {
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, path));
            }
        }
       
        private string FileVersionCheckAndUpdate(string filename, string path, string ext)
        {
            int count = 1;
            string newFileName = filename;
            string newPath = Path.Combine(path, filename + ext);
            while (System.IO.File.Exists(Path.Combine(_hostingEnvironment.WebRootPath, newPath)))
            {
                newFileName = string.Format("{0}({1})", filename, count++);
                newPath = Path.Combine(path, newFileName + ext);
            }
            return newFileName;
        }

        private string UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string name = Path.GetFileNameWithoutExtension(file.FileName);
                string ext = Path.GetExtension(file.FileName);
                string fileDirectoryName = GenerateFileDirectoryName();
                CheckAndCreateDirectory($"Upload/{ fileDirectoryName }");
                name = FileVersionCheckAndUpdate(name, $"Upload/{ fileDirectoryName }", ext);
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "Upload", fileDirectoryName + name + ext);

                using (var stream = System.IO.File.Create(path))
                {
                    file.CopyTo(stream);
                }
                return Path.Combine("Upload", fileDirectoryName + name + ext); ;
            }
            return string.Empty;
        }

    }
}