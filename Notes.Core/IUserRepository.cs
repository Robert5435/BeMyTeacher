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
        void EditUser(int id,string phoneNumber, string path);
        void RateUser(int id, int rate);
    }
}
