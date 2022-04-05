using AutoMapper;
using BeMyTeacher.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeMyTeacher.Core
{
    public class TutoringAdsServices : ITutoringAdsServices
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public TutoringAdsServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ViewModelTutoringAd GetTutoringAd(int id)
        {
            var ads = GetViewModelTutoringAds();
            var ad = ads.First(a => a.Id == id);
            return ad;
        }
        public List<TutoringAd> GetTutoringAds()
        {
            var ads = _context.TutoringAds.ToList();
            ads = ads.OrderByDescending(a => a.ExpirationDate).ToList();
            return ads;
        }

        public List<ViewModelTutoringAd> GetViewModelTutoringAds(int? selectedSubjectId = null, int? selectedLocationId = null, int? userId = null)
        {
            var ads = _context.TutoringAds.Include(a => a.Calification).Include(a => a.Subject).Include(a => a.Location).Include(a => a.EducationLevel).Include(a => a.User).ToList();
            ads = ads.OrderByDescending(a => a.ExpirationDate).ToList();
            if (userId.HasValue)
            {
                ads = ads.Where(a => a.UserId == userId).ToList();
            }

            if (selectedSubjectId.HasValue)
            {
                ads = ads.Where(a => a.SubjectId == selectedSubjectId).ToList();
            }

            if (selectedLocationId.HasValue)
            {
                ads = ads.Where(a => a.LocationId == selectedLocationId).ToList();
            }
            List<ViewModelTutoringAd> modelAds = new List<ViewModelTutoringAd>();
            foreach(var ad in ads)
            {
                var adModel = _mapper.Map<ViewModelTutoringAd>(ad);
                modelAds.Add(adModel);
            }
            return modelAds;
        }

        public TutoringAd CreateTutoringAd(TutoringAd tutoringAd)
        {
            _context.Add(tutoringAd);
            _context.SaveChanges();

            return tutoringAd;
        }

        public void DeleteTutoringAd(int id, int userId)
        {
            var tutoringAd = _context.TutoringAds.First(n => n.Id == id);
            if(tutoringAd.UserId != userId)
            {
                throw new Exception("Can not delete the ad of another user");
            }
            else
            {
                _context.TutoringAds.Remove(tutoringAd);
                _context.SaveChanges();
            }

        }

        public void EditTutoringAd(TutoringAd tutoringAd,int userId)
        {
            var editedAd = _context.TutoringAds.First(n => n.Id == tutoringAd.Id);

            editedAd.ExpirationDate = tutoringAd.ExpirationDate;
            editedAd.UserId = userId;
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