using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SosyalEtkinlikWEB.Context;
using SosyalEtkinlikWEB.DataProvider.IDataProvider;
using SosyalEtkinlikWEB.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SEtkinlikWeb.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        IEtkinlikDataProvider _dp;
        public KullaniciController(IEtkinlikDataProvider etkinlikDataProvider)
        {
            _dp = etkinlikDataProvider;
        }
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(Kullanici kullanici)
        {

            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            _dp.KAdd(kullanici);
            return RedirectToAction("Giris");
        }

        public IActionResult Giris()
        {
            return View();
        }

        private Kullanici kullaniciID = new Kullanici();

        [HttpPost]
        public IActionResult Giris(string email,string sifre)
        {
            if (!ModelState.IsValid)
            {
                return View("Giris");
            }
            foreach(var item in _dp.KgetList())
            {
                if(item.KEmail==email && item.KSifre == sifre)
                {
                    KullaniciID.Kid = item.Kid;
                    KullaniciID.KAd = item.KAd;
                    KullaniciID.KSoyad = item.KSoyad;
                    KullaniciID.KEmail = item.KEmail;
                    KullaniciID.KSifre = item.KSifre;
                    return RedirectToAction("Sayfam",item);
                }
            }
            return View("Giris");
        }


        public IActionResult Sayfam( Kullanici kullanici )
        {
            return View(kullanici);
        }

        public IActionResult SGcevirici(int id)
        {
            var etk = _dp.EGet(id);
            var klnc = _dp.KGet(etk.Kid);
            return RedirectToAction("Sayfam", klnc);
        }
        public IActionResult EGcevirici(int id)
        {
            var klnc = _dp.KGet(id);
            return RedirectToAction("Sayfam", klnc);
        }
        public IActionResult EKcevirici(int id)
        {
            var klnc = _dp.KGet(id);
            return RedirectToAction("Sayfam", klnc);
        }


        Etkinlikler etknlk = new Etkinlikler();

        public Kullanici KullaniciID { get => kullaniciID; set => kullaniciID = value; }

        public IActionResult EtkinlikKur(int id)
        {
            DateTime date = DateTime.Today;
            etknlk.Kid = id;
            etknlk.EUcret = 0;
            etknlk.EBiletAdet = 0;
            etknlk.ETarih = date;
            return View(etknlk);
        }

        [HttpPost]
        public IActionResult EtkinlikKur(Etkinlikler etkinlik)
        {
            if (!ModelState.IsValid)
            {
                return View("EtkinlikKur");
            }

            var klnc = _dp.KGet(etkinlik.Kid);
            _dp.EAdd(etkinlik);
            return RedirectToAction("Sayfam",klnc);
        }



        public IActionResult SatisGoster(int id)
        {
            var result3 = new List<Satis>();
            var result2 = _dp.EgetList().Where(f => f.Kid == id).ToList();
            foreach (var item in result2)
            {
                var result = _dp.SgetList().Where(f => f.Eid == item.Eid);
                foreach (var item2 in result)
                {
                    result3.Add(item2);
                }
            }
            return View(result3);
        }


        public IActionResult EtkinlikGoster(int id)
        {
            var result = _dp.EgetList().Where(f => f.Kid == id).ToList();
            return View(result);
        }


        public IActionResult SatisSil(int id)
        {
            var sts = _dp.SGet(id);
            var kid = _dp.EGet(sts.Eid).Kid;
            sts.Etkinlikler = _dp.EGet(sts.Eid);
            sts.Etkinlikler.EBiletAdet = sts.Etkinlikler.EBiletAdet + sts.SBiletAdeti;
            _dp.EUpdate(sts.Etkinlikler);
            _dp.Ssil(id);
            return RedirectToAction("SatisGoster", kid);
        }

        public IActionResult EtkinlikSil(int id)
        {
            var kid = _dp.EGet(id).Kid;
            _dp.Esil(id);
            return RedirectToAction("EtkinlikGoster", kid);
        }

        public IActionResult KullaniciSil(int id)
        {
            _dp.Ksil(id);
            return RedirectToAction("Index", "Etkinlik");
        }


        public IActionResult SatisGuncelle(int id)
        {
            var result = _dp.SGet(id);
            result.Etkinlikler = _dp.EGet(result.Eid);
            return View(result);
        }
        [HttpPost]
        public IActionResult SatisGuncelle(Satis satis)
        {
            satis.Etkinlikler = _dp.EGet(satis.Eid);
            _dp.SUpdate(satis);
            return View(satis);
        }


        public IActionResult EtkinlikGuncelle(int id)
        {
            var result = _dp.EGet(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult EtkinlikGuncelle(Etkinlikler etkinlikler)
        {
            _dp.EUpdate(etkinlikler);
            return View(etkinlikler);
        }

        
        public IActionResult KullaniciGuncelle(int id)
        {
            var result=_dp.KGet(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult KullaniciGuncelle(Kullanici kullanici)
        {
            _dp.KUpdate(kullanici);
            return View(kullanici);
        }
        

    }

}