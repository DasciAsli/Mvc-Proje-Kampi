using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class AdminManager: IAdminService
    {

        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public void AdminAdd(Admin admin)
        {
            _admindal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _admindal.Delete(admin);
           
        }

        public void AdminUpdate(Admin admin)
        {
            _admindal.Update(admin);
            
        }

        public Admin GetByID(int id)
        {
            return _admindal.Get(x => x.AdminId == id);
        }

        public List<Admin> GetListAdmin(Admin admin)
        {
            return _admindal.List(x=>x.AdminUserName==admin.AdminUserName && x.AdminPassword==admin.AdminPassword);
        }

        public List<Admin> GetList()
        {
            return _admindal.List();
        }
    }
}
