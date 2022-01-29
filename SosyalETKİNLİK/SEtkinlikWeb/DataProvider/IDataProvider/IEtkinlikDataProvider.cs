using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SosyalEtkinlikWEB.Entities;
namespace SosyalEtkinlikWEB.DataProvider.IDataProvider
{
    public interface IEtkinlikDataProvider
    {
        string EAdd(Etkinlikler etkinlikler);
        string KAdd(Kullanici kullanici);
        string SAdd(Satis satis);
        List<Etkinlikler> EgetList();
        List<Satis> SgetList();
        List<Kullanici> KgetList();
        Etkinlikler EGet(int id);
        Kullanici KGet(int id);
        Satis SGet(int id);
        void Esil(int id);
        void Ssil(int id);
        void Ksil(int id);
        void EUpdate(Etkinlikler etkinlikler);
        void KUpdate(Kullanici kullanici);
        void SUpdate(Satis satis);
    }
}