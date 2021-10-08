﻿using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeMyTeacher.Core
{
    public class TutoringAdsServices : ITutoringAdsServices
    {
        private AppDbContext _context;

        public TutoringAdsServices(AppDbContext context)
        {
            _context = context;
        }

        public TutoringAd GetTutoringAd(int id)
        {
            return _context.TutoringAds.First(a => a.Id == id);
        }
        public List<TutoringAd> GetTutoringAds()
        {
            return _context.TutoringAds.ToList();
        }

        public TutoringAd CreateTutoringAd(TutoringAd tutoringAd)
        {
            _context.Add(tutoringAd);
            _context.SaveChanges();

            return tutoringAd;
        }

        public void DeleteTutoringAd(int id)
        {
            var tutoringAd = _context.TutoringAds.First(n => n.Id == id);
            _context.TutoringAds.Remove(tutoringAd);
            _context.SaveChanges();
        }

        public void EditTutoringAd(TutoringAd tutoringAd)
        {
            var editedAd = _context.TutoringAds.First(n => n.Id == tutoringAd.Id);
            editedAd.UserId = tutoringAd.UserId;
            editedAd.LocationId = tutoringAd.LocationId;
            editedAd.SubjectId = tutoringAd.SubjectId;
            editedAd.EducationLevelId = tutoringAd.EducationLevelId;
            editedAd.CalificationId = tutoringAd.CalificationId;
            editedAd.Title = tutoringAd.Title;
            editedAd.Content = tutoringAd.Content;
            editedAd.Active = tutoringAd.Active;
            editedAd.AvailabilityOnline = tutoringAd.AvailabilityOnline;
            editedAd.AvailabilityHome = tutoringAd.AvailabilityHome;
            editedAd.AvailabilityStudentHome = tutoringAd.AvailabilityStudentHome;
            editedAd.PricePerSession = tutoringAd.PricePerSession;
            editedAd.SessionLenghtinMinutes = tutoringAd.SessionLenghtinMinutes;
            editedAd.ExpirationDate = tutoringAd.ExpirationDate;
            editedAd.Subject = tutoringAd.Subject;
            editedAd.Calification = tutoringAd.Calification;
            editedAd.Location = tutoringAd.Location;
            editedAd.EducationLevel = tutoringAd.EducationLevel;
            _context.SaveChanges();
        }
    }
}
