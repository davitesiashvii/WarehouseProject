using BLL.DTO.Production;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IProductionOperation
    {
        public IEnumerable<ProductionDTO> GetAllProduction(string searchTrem);

        public void Create(CreateProductionDTO model);

        CreateProductionDTO GetEditProduction(int Id);

        void Edit(CreateProductionDTO model);

        public void Delete(int id);




    }
}
