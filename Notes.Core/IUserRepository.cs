using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.Core
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
