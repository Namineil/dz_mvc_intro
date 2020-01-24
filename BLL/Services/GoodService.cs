using BLL.DTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class GoodService : IService<GoodDTO>
	{
		IRepository<Good> goodRepo;
		public GoodService(IRepository<Good> goodRepo)
		{
			this.goodRepo = goodRepo;
		}

		public GoodDTO CreateOrUpdate(GoodDTO dto)
		{
			Good newGood = new Good
			{
				GoodId = dto.GoodId,
				GoodName = dto.GoodName,
				GoodCount = dto.GoodCount,
				Price = dto.Price,
				CategoryId = dto.CategoryId,
				ManufacturerId = dto.ManufacturerId
			};
			goodRepo.CreateOrUpdate(newGood);
			return new GoodDTO
			{
				GoodId = newGood.GoodId,
				GoodName = newGood.GoodName,
				Price = newGood.Price,
				GoodCount = newGood.GoodCount,
				CategoryId = newGood.CategoryId,
				ManufacturerId = newGood.ManufacturerId,
				CategoryName = newGood.Category?.CategoryName,
				ManufacturerName = newGood.Manufacturer?.ManufacturerName
			};
		}

		public GoodDTO Get(int id)
		{
			var good = goodRepo.Get(id);
			return new GoodDTO
			{
				GoodId = good.GoodId,
				GoodName = good.GoodName,
				Price = good.Price,
				GoodCount = good.GoodCount,
				CategoryId = good.CategoryId,
				ManufacturerId = good.ManufacturerId,
				CategoryName = good.Category?.CategoryName,
				ManufacturerName = good.Manufacturer?.ManufacturerName
			};
		}

		public IEnumerable<GoodDTO> ListAll()
		{
			return goodRepo
					.GetAll()
						.Select(x => new GoodDTO
						{
							GoodId = x.GoodId,
							GoodName = x.GoodName,
							Price = x.Price,
							GoodCount = x.GoodCount,
							CategoryId = x.CategoryId,
							ManufacturerId = x.ManufacturerId,
							CategoryName = x.Category?.CategoryName,
							ManufacturerName = x.Manufacturer?.ManufacturerName
						}); 
		}

		public GoodDTO Remove(GoodDTO dto)
		{
			Good good = new Good
			{
				GoodId = dto.GoodId,
				GoodName = dto.GoodName,
				GoodCount = dto.GoodCount,
				Price = dto.Price,
				CategoryId = dto.CategoryId,
				ManufacturerId = dto.ManufacturerId
			};
			goodRepo.Delete(good);
			return dto;
		}

		public void Save()
		{
			goodRepo.Save();
		}
	}
}
