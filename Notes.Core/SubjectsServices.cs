using AutoMapper;
using BeMyTeacher.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeMyTeacher.Core
{
    public class SubjectsServices : ISubjectsServices
    {
        private AppDbContext _context;
        public SubjectsServices(AppDbContext context)
        {
            _context = context;
        }

        public void CreateSubject(Subject subject)
        {
            _context.Add(subject);
            _context.SaveChanges();
        }

        public void DeleteSubjects(int id)
        {
            var subject = _context.Subjects.First(a => a.Id == id);
            _context.Remove(subject);
            _context.SaveChanges();
        }

        public Subject GetSubject(int id)
        {
            return _context.Subjects.First(a => a.Id == id);
        }
        public List<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }
    }
}
