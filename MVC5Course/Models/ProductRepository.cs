using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p =>p.Is�R�� == false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get�Ҧ����_�̾�ProductId�Ƨ�(int Size)
        {
            return this.All().OrderByDescending(p => p.ProductId).Take(Size);
        }

        public override void Delete(Product entity)
        {
            entity.Is�R�� = true;
            //this.UnitOfWork.Commit(); -->���~�hController��Commit
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}