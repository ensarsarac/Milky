using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void TDelete(int id)
		{
			_productDal.Delete(id);
		}

		public Product TGetById(int id)
		{
			return _productDal.GetById(id);
		}

        public Product TGetByIdProductWithCategory(int id)
        {
			return _productDal.GetByIdProductWithCategory(id);
        }

        public List<Product> TGetList()
		{
			return _productDal.GetList();
		}

        public List<Product> TGetProductListWithCategory()
        {
            return _productDal.GetProductListWithCategory();
        }

        public void TInsert(Product entity)
		{
			_productDal.Insert(entity);
		}

		public void TUpdate(Product entity)
		{
			_productDal.Update(entity);
		}
	}
}
