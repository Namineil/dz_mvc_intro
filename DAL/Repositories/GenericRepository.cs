using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public abstract class GenericRepository<T> : IRepository<T> where T: class
	{
		DbContext context;
		IDbSet<T> dbSet;
		public GenericRepository(DbContext context)
		{
			this.context = context;
			dbSet = context.Set<T>();
		}

		public void CreateOrUpdate(T entity)
		{
			dbSet.AddOrUpdate(entity);
	
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public T Get(int id)
		{
			return dbSet.Find(id);
		}

		public IEnumerable<T> GetAll()
		{
            Thread.Sleep(4000);
			return dbSet;
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
