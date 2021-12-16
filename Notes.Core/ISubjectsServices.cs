using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.Core
{
    public interface ISubjectsServices
    {
        Subject GetSubject(int id);
        List<Subject> GetSubjects();
    }
}
