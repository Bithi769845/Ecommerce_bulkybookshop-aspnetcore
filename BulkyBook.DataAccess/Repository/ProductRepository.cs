using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    

        public void Update(Product obj)
        {
            var objFromDb = _db.product.FirstOrDefault(s => s.id == obj.id);
            if(objFromDb != null)
            {
                objFromDb.title = obj.title;
                objFromDb.Discription = obj.Discription;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Author = obj.Author;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.price = obj.price;
                objFromDb.price50 = obj.price50;
                objFromDb.price100 = obj.price100;
                objFromDb.categoryId = obj.categoryId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
