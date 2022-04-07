using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.Core
{
    public interface ICalificationsServices
    {
        Calification GetCalification(int id);
        List<Calification> GetAllCalifications();
        void CreateCalification(string name);
        void DeleteCalification(int id);
    }
}
