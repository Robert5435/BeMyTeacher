using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.Core
{
    public interface IEducationLevels
    {
        EducationLevel GetEducationLevel(int id);
        List<EducationLevel> GetEducations();
        void CreateEducationLevel(string name);
        void DeleteEducationLevel(int id);
    }
}
