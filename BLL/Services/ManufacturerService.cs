using BLL.DTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ManufacturerService : IService<ManufacturerDTO>
    {
        IRepository<Manufacturer> manufacturerRepo;
        public ManufacturerService(IRepository<Manufacturer> manufacturerRepo)
        {
            this.manufacturerRepo = manufacturerRepo;
        }

        public ManufacturerDTO CreateOrUpdate(ManufacturerDTO dto)
        {
            Manufacturer newManufacturer = new Manufacturer
            {
                ManufacturerId = dto.ManufacturerId,
                ManufacturerName = dto.ManufacturerName
            };
            manufacturerRepo.CreateOrUpdate(newManufacturer);
            return new ManufacturerDTO
            {
                ManufacturerId = newManufacturer.ManufacturerId,
                ManufacturerName = newManufacturer.ManufacturerName
            };
        }

        public ManufacturerDTO Get(int id)
        {
            var manufacturer = manufacturerRepo.Get(id);
            return new ManufacturerDTO
            {
                ManufacturerId = manufacturer.ManufacturerId,
                ManufacturerName = manufacturer.ManufacturerName
            };
        }

        public IEnumerable<ManufacturerDTO> ListAll()
        {
            return manufacturerRepo
                    .GetAll()
                        .Select(x => new ManufacturerDTO
                        {
                            ManufacturerId = x.ManufacturerId,
                            ManufacturerName = x.ManufacturerName
                        });
        }

        public ManufacturerDTO Remove(ManufacturerDTO dto)
        {
            Manufacturer manufacturer = new Manufacturer
            {
                ManufacturerId = dto.ManufacturerId,
                ManufacturerName = dto.ManufacturerName
            };
            manufacturerRepo.Delete(manufacturer);
            return dto;
        }

        public void Save()
        {
            manufacturerRepo.Save();
        }
    }
}
