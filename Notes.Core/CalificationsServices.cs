using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeMyTeacher.Core
{
    internal class CalificationsServices : ICalificationsServices
    {
        private AppDbContext _context;

        public CalificationsServices(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCalification(string name)
        {
            var calification = new Calification
            { 
                Name = name 
            };
            _context.Add(calification);
            _context.SaveChanges(); 
        }

        public void DeleteCalification(int id)
        {
            var calification = _context.Califications.First(a => a.Id == id);
            _context.Remove(calification);
            _context.SaveChanges();
        }

        public List<Calification> GetAllCalifications()
        {
            return _context.Califications.ToList(); 
        }

        public Calification GetCalification(int id)
        {
            return _context.Califications.First(c => c.Id == id);
        }
    }
}
