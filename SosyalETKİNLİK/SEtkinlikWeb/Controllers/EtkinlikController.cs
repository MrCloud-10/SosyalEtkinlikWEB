using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SosyalEtkinlikWEB.DataProvider.IDataProvider;
using SosyalEtkinlikWEB.Entities;

namespace SEtkinlikWeb.Controllers
{
    public class EtkinlikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        IEtkinlikDataProvider _dp;
        public EtkinlikController(IEtkinlikDataProvider etkinlikDataProvider)
        {
            _dp = etkinlikDataProvider;
        }

        public IActionResult EtkinlikGoruntule(string str)
        {
            DateTime date = DateTime.Now;
            var result = _dp.EgetList();
            if (!string.IsNullOrEmpty(str))
            {
                result = result.Where(m => m.Kategori.ToUpper().Contains(str.ToUpper())).ToList();
            }
            result = result.Where(m => m.EBiletAdet != 0).ToList();
            result = result.Where(m => m.ETarih >= date).ToList();
            return View(result);
        }

        public IActionResult SatisEkle(int id)
        {
            Satis satis = new Satis();
            var result = _dp.EGet(id);
            satis.Eid = result.Eid;
            satis.Etkinlikler = result;
            satis.SOdenecekTutar = result.EUcret;
            return View(satis);
        }
        [HttpPost]
        public IActionResult SatisEkle(Satis satis)
        {
            satis.SOdenecekTutar = satis.SOdenecekTutar * satis.SBiletAdeti;
            var etk = _dp.EGet(satis.Eid);
            etk.EBiletAdet = etk.EBiletAdet - satis.SBiletAdeti;
            _dp.EUpdate(etk);
            _dp.SAdd(satis);
            return RedirectToAction("EtkinlikGoruntule");
        }
    }
}