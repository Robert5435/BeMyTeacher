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
        private readonly IMapper _mapper;

        public SubjectsServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
