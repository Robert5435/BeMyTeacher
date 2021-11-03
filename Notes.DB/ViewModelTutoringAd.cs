using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.DB
{
   public class ViewModelTutoringAd
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string Calification { get; set; }
        public bool AvailabilityOnline { get; set; }
        public bool AvailabilityHome { get; set; }
        public bool AvailabilityStudentHome { get; set; }
        public string Location { get; set; }
        public int Price { get; set; }
        public int LenghtInMinutes { get; set; }
        public DateTime Date { get; set; }

    }
}
