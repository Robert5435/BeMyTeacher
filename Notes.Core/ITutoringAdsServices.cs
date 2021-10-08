﻿using BeMyTeacher.DB;
using System.Collections.Generic;

namespace BeMyTeacher.Core
{
    public interface ITutoringAdsServices
    {
        TutoringAd GetTutoringAd(int id);
        TutoringAd CreateTutoringAd(TutoringAd tutoringAd);
        void DeleteTutoringAd(int id);
        void EditTutoringAd(TutoringAd tutoringAd);
        List<TutoringAd> GetTutoringAds();
    }
}