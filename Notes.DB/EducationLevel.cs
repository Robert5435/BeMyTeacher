using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.DB
{
    public class EducationLevel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TutoringAd> TutoringAds { get; set; }
    }
}
