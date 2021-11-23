﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        DbSet<Category> _object;

        public void Delete(Category p)
        {
            _object.Remove(p); //Silme işlemi
            c.SaveChanges();
        }

        public void Insert(Category p)
        {
            _object.Add(p);//Ekleme işlemi
            c.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList(); //Listeleme işlemi
        }

        public void Update(Category p)
        {
            c.SaveChanges(); 

        }
    }
}