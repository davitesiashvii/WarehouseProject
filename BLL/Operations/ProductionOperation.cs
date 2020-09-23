using AutoMapper;
using BLL.DTO.Production;
using BLL.Interfaces;
using DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operations
{
    public class ProductionOperation:IProductionOperation
    {
        private readonly IUOW _service;
        private readonly IMapper _mapper;

        public ProductionOperation(IUOW service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }

        public IEnumerable<ProductionDTO> GetAllProduction(string searchTrem)
        {
            var Production = _service.Production.Search(searchTrem);

            return _mapper.Map<IEnumerable<ProductionDTO>>(Production);

        }

        public CreateProductionDTO GetEditProduction(int Id)
        {
            var production= _service.Production.GetProduction(Id);
            return _mapper.Map<CreateProductionDTO>(production);
        }

        public void Create(CreateProductionDTO model)
        {
            Production dbModel = _mapper.Map<Production>(model);
            _service.Production.Create(dbModel);
            _service.Commit();
        }

        public void Edit(CreateProductionDTO model)
        {
            var dbModel = _service.Production.GetProduction(model.Id);
            if (dbModel == null)
            {
                throw new Exception("object not found");
            }

            _mapper.Map<CreateProductionDTO,Production>(model,dbModel);
            _service.Production.Update(dbModel);
            _service.Commit();
        }

        public void Delete (int id)
        {
            var Producction = _service.Production.GetProduction(id);
            _service.Production.Delete(Producction);
            _service.Commit();

        }
    }
}
