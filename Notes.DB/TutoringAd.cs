using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.DB
{
    public class TutoringAd
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int LocationId { get; set; }

        public int SubjectId { get; set; }

        public int EducationLevelId { get; set; }

        public int CalificationId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool Active { get; set; }

        public bool AvailabilityOnline { get; set; }

        public bool AvailabilityHome { get; set; }

        public bool AvailabilityStudentHome { get; set; }

        public int PricePerSession { get; set; }

        public int SessionLenghtinMinutes { get; set; }
        public string PhotoPath { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Subject Subject { get; set; }

        public Calification Calification { get; set; }

        public Location Location { get; set; }

        public EducationLevel EducationLevel { get; set; }
        public User User { get; set; }
    }
}
