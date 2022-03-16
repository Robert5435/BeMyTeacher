using BeMyTeacher.DB;
using System.Collections.Generic;

namespace BeMyTeacher.Core
{
    public interface ITutoringAdsServices
    {
        ViewModelTutoringAd GetTutoringAd(int id);
        TutoringAd CreateTutoringAd(TutoringAd tutoringAd);
        void DeleteTutoringAd(int id,int userId);
        void EditTutoringAd(TutoringAd tutoringAd, int userId);
        List<TutoringAd> GetTutoringAds();
        List<ViewModelTutoringAd> GetViewModelTutoringAds( int? selectedSubjectId = null, int? selectedLocationId = null, int? userId = null);


    }
}