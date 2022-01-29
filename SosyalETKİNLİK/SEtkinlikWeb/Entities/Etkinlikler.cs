using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SosyalEtkinlikWEB.Entities
{
    public class Etkinlikler
    {
        public Etkinlikler()
        {
            this.Satis = new HashSet<Satis>();
        }

        [DataMember]
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Eid { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        [StringLength(500, ErrorMessage = "Bu Alan İçin Ayrılan Karakter Sayısını(500) Aştınız.Lütfen Düzenleyiniz!")]
        public string EIcerik { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        public DateTime ETarih { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        public decimal EUcret { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        [StringLength(50, ErrorMessage = "Bu Alan İçin Ayrılan Karakter Sayısını(50) Aştınız.Lütfen Düzenleyiniz!")]
        public string Kategori { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("Kid")]
        public int Kid { get; set; }
        public Kullanici Kullanici { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        public int EBiletAdet { get; set; }

        public ICollection<Satis> Satis { get; set; }
    }
}