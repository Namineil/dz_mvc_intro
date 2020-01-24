using BLL.DTO;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Modules
{
	public class ShopDIModule : NinjectModule
	{
		public override void Load()
		{
			Bind<DbContext>().To<ShopContext>();
			Bind<IRepository<Good>>().To<GoodRepository>();
			Bind<IService<GoodDTO>>().To<GoodService>();

		}
	}
}
