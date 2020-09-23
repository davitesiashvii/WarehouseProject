using AutoMapper;
using BLL.DTO.Shope;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class ShopeOperation:IShopeOperation
    {
        private readonly IUOW _service;
        private readonly IMapper _mapper;
        public ShopeOperation(IUOW sercice, IMapper mapper)
        {
            _service = sercice;
            _mapper = mapper;        
        }

        public void Create(ShopeFormDTO model)
        {
            Shope dbModel = _mapper.Map<Shope>(model);
            _service.Shope.Create(dbModel);
            _service.Commit();
        }

        public void Edit(ShopeFormDTO model)
        {
            var dbModel = _service.Shope.GetShope(model.Id);
            if (dbModel == null)
            {
                throw new Exception("object not found");
            }

            _mapper.Map<ShopeFormDTO, Shope>(model, dbModel);
            _service.Shope.Update(dbModel);
            _service.Commit();
        }

        

        public IEnumerable<ShopeDTO> GetAllShope()
        {
            
            var shope1 = _service.Shope.GetAllShope();
            return _mapper.Map<IEnumerable<ShopeDTO>>(shope1);
           
        }
        
        public ShopeFormDTO GetEditShope(int Id)
        {
            var shope = _service.Shope.GetShope(Id);
            return _mapper.Map<ShopeFormDTO>(shope);
        }

        public CreateShopeComponents GetComponents()
        {
            CreateShopeComponents components = new CreateShopeComponents();
            var Productions = _service.Production.FindAll();
            components.ProductionList = Productions.Select(x => new SelectListItem() { Text = $"{x.Name} {x.ManufacturerCompany}", Value = x.Id.ToString() }).ToList();
            return components;
        }

        public IEnumerable<ShopeDTO> Search(string searchTrem)
        {
            var shope = _service.Shope.Search(searchTrem);
            return _mapper.Map<IEnumerable<ShopeDTO>>(shope);
           
            
        }

        public void Delete(int id)
        {
            var Shope = _service.Shope.GetShope(id);
            _service.Shope.Delete(Shope);
            _service.Commit();
        }
    }
}
