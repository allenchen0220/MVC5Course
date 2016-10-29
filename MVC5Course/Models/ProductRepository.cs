using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p =>p.Is刪除 == false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get所有資料_依據ProductId排序(int Size)
        {
            return this.All().OrderByDescending(p => p.ProductId).Take(Size);
        }

        public override void Delete(Product entity)
        {
            entity.Is刪除 = true;
            //this.UnitOfWork.Commit(); -->放到外層Controller做Commit
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}