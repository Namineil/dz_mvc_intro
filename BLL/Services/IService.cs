using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public interface IService<T> where T: class
	{
		T Get(int id);
		IEnumerable<T> ListAll();
		T CreateOrUpdate(T dto);
		T Remove(T dto);
		void Save();
	}
}
