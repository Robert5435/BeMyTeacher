using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.DB
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public ICollection<TutoringAd> TutoringAds { get; set; }
    }
}
