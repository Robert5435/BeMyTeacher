using System;
using System.Collections.Generic;
using System.Text;

namespace BeMyTeacher.DB
{
   public class ViewModelTutoringAd
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int LocationId { get; set; }
        public int CalificationId { get; set; }
        public int EducationLevelId { get; set; }
        public string PhotoPath { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPhoto { get; set; }
        public int RatingCounter { get; set; }
        public int RatingUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string Calification { get; set; }
        public string EducationLevel { get; set; }
        public bool AvailabilityOnline { get; set; }
        public bool AvailabilityHome { get; set; }
        public bool AvailabilityStudentHome { get; set; }
        public string Location { get; set; }
        public int PricePerSession { get; set; }
        public int SessionLenghtinMinutes { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
