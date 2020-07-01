using System;
using System.Collections.Generic;
using System.Text;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;

namespace Asset.Repository.UserAdmin
{
    public class UserUnitOfWork:UnitOfWork
    {
        public UserUnitOfWork() : base(new useradminContext())
        {
        }
       public  UserRepository GetUserRepository()
        {
            return base.Repository<TUserMaster>() as UserRepository;
        }
        public RolesLinkedToUserRepository GetUserRoleReposity()
        {
            
            return base.Repository<TUserProfile>() as RolesLinkedToUserRepository;
        }
    }


}
