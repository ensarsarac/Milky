using Microsoft.EntityFrameworkCore;
using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Concrete;
using Milky.DataAccessLayer.Repositories;
using Milky.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.EntityFramework
{
	public class ProductRepository : GenericRepositories<Product>, IProductDal
	{
        private readonly MilkyContext _context;
		public ProductRepository(MilkyContext context) : base(context)
		{
            _context = context;
		}

        public Product GetByIdProductWithCategory(int id)
        {
            var values = _context.Products.Where(x => x.ProductId == id).Include(p => p.Category).FirstOrDefault();
            return values;
        }

        public List<Product> GetProductListWithCategory()
        {
            var values = _context.Products.Include(p => p.Category).ToList();
            return values;
        }
    }
}
