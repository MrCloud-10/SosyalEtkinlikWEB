using Microsoft.AspNetCore.Mvc;
using SosyalEtkinlikWEB.Context;
using SosyalEtkinlikWEB.DataProvider.IDataProvider;
using SosyalEtkinlikWEB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosyalEtkinlikWEB.DataProvider.EFDataProvider
{
    public class EFEtkinlikDataProvider : IEtkinlikDataProvider
    {
        

        public string EAdd(Etkinlikler etkinlikler)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                mcontext.Etkinlikler.Add(etkinlikler);
                mcontext.SaveChanges();
            }
            return "Tamamdır";
        }

        public string KAdd(Kullanici kullanici)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                mcontext.Kullanici.Add(kullanici);
                mcontext.SaveChanges();
            }
            return "Tamamdır.";
        }



        public string SAdd(Satis satis)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                mcontext.Satis.Add(satis);
                mcontext.SaveChanges();
            }
            return "Tamamdır.";
        }
        public List<Etkinlikler> EgetList()
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result = mcontext.Etkinlikler.ToList();
                foreach(var item in result)
                {
                    item.Kullanici = KGet(item.Kid);
                }
                return result;
            }
        }


        public List<Satis> SgetList()
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result = mcontext.Satis.ToList();
                return result;
            }
        }
        public List<Kullanici> KgetList()
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result = mcontext.Kullanici.ToList();
                return result;
            }
        }
        public Etkinlikler EGet(int id)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result = mcontext.Etkinlikler.FirstOrDefault(f => f.Eid == id);
                return result;
            }
        }
        public Kullanici KGet(int id)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result = mcontext.Kullanici.FirstOrDefault(f => f.Kid == id);
                return result;
            }
        }

        public Satis SGet(int id)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result = mcontext.Satis.FirstOrDefault(f => f.Sid == id);
                return result;
            }
        }
        public void Ssil(int id)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result = mcontext.Satis.Find(id);
                mcontext.Satis.Remove(result);
                mcontext.SaveChanges();
            }
        }
        public void Esil(int id)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result2 = mcontext.Satis.ToList().Where(f => f.Eid == id);
                foreach (var item in result2  )
                {
                    var result3 = mcontext.Satis.Find(item.Sid);
                    mcontext.Satis.Remove(result3);
                }
                var result = mcontext.Etkinlikler.Find(id);
                mcontext.Etkinlikler.Remove(result);
                mcontext.SaveChanges();
            }
        }
        public void Ksil(int id)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                var result2 = mcontext.Etkinlikler.ToList().Where(f => f.Kid == id);
                foreach (var item in result2)
                {
                    var result4 = mcontext.Satis.ToList().Where(f => f.Eid == id);
                    foreach (var item1 in result4)
                    {
                        var result3 = mcontext.Satis.Find(item1.Sid);
                        mcontext.Satis.Remove(result3);
                    }
                    var result5 = mcontext.Etkinlikler.Find(item.Eid);
                    mcontext.Etkinlikler.Remove(result5);
                }
                var result = mcontext.Kullanici.Find(id);
                mcontext.Kullanici.Remove(result);
                mcontext.SaveChanges();
            }
        }

        public void EUpdate(Etkinlikler etkinlikler)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                mcontext.Etkinlikler.Update(etkinlikler);
                mcontext.SaveChanges();
            }

        }
        public void KUpdate(Kullanici kullanici)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                mcontext.Kullanici.Update(kullanici);
                mcontext.SaveChanges();
            }

        }
        public void SUpdate(Satis satis)
        {
            using (var mcontext = new EtkinlikDBContext())
            {
                mcontext.Satis.Update(satis);
                mcontext.SaveChanges();
            }

        }
    }
}