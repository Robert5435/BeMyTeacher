using BeMyTeacher.DB;
using System.Collections.Generic;

namespace BeMyTeacher.Core
{
    public interface ITutoringAdsServices
    {
        ViewModelTutoringAd GetTutoringAd(int id);
        TutoringAd CreateTutoringAd(TutoringAd tutoringAd);
        void DeleteTutoringAd(int id);
        void EditTutoringAd(TutoringAd tutoringAd);
        List<TutoringAd> GetTutoringAds();
        List<ViewModelTutoringAd> GetViewModelTutoringAds( int? selectedSubjectId = null, int? selectedLocationId = null);
    }
}