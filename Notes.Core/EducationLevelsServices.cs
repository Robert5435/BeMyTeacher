using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeMyTeacher.Core
{
    internal class EducationLevelsServices : IEducationLevels
    {
        private AppDbContext _context;

        public EducationLevelsServices(AppDbContext context)
        {
            _context = context;
        }

        public void CreateEducationLevel(string name)
        {
            var level = new EducationLevel
            {
                Name = name
            };
            _context.Add(level);
            _context.SaveChanges();

        }

        public void DeleteEducationLevel(int id)
        {
            var level = _context.EducationLevels.First(a => a.Id == id);
        }

        public EducationLevel GetEducationLevel(int id)
        {
            return _context.EducationLevels.First(a => a.Id == id); 
        }

        public List<EducationLevel> GetEducations()
        {
            return _context.EducationLevels.ToList();
        }
    }
}
