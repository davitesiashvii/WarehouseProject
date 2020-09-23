using BLL.DTO.Shope;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IShopeOperation
    {
        public IEnumerable<ShopeDTO> GetAllShope();

        public IEnumerable<ShopeDTO> Search(string searchTrem);

        public void Create(ShopeFormDTO model);

        ShopeFormDTO GetEditShope(int Id);

        void Edit(ShopeFormDTO model);

        public void Delete(int id);

        public CreateShopeComponents GetComponents();

        //CreateShopeComponents GetComponents();
    }
}
