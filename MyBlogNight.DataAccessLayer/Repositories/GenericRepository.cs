using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class//Dışarıdan bir T değeri alsın Igenericdaldan miras alsın bu T de bir class olsun
    {
        private readonly BlogContext _context; //oluşturmuş olduğum fieldıma(_context) sadece private reodonly üzerinden erişim sağlansın. 

        public GenericRepository(BlogContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var value = _context.Set<T>().Find(id); //Value benim dışardan oluşturduğum entitiy nesnemi bul
            _context.Set<T>().Remove(value); //Tye göre ayarla valueden gelen değeri sil
            _context.SaveChanges();
        }

        public List<T> GetAll() //Void bir metot olmadığından geriye değer döndürmemi istiyor.
        {
            return _context.Set<T>().ToList(); //Bizim gönderdiğimiz t değerine göre bütün verileri getir.
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
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
