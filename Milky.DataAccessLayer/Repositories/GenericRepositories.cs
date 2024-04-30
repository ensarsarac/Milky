using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.Repositories
{
	public class GenericRepositories<T> : IGenericDal<T> where T : class
	{
		private readonly MilkyContext _context;

		public GenericRepositories(MilkyContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			_context.Set<T>().Remove(_context.Set<T>().Find(id));
			_context.SaveChanges();	
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetList()
		{
			return _context.Set<T>().ToList();
		}

		public void Insert(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
			_context.SaveChanges();
		}
	}
}
