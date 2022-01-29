using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SosyalEtkinlikWEB.Entities
{
    public class Kullanici
    {
        public Kullanici()
        {
            this.Etkinlik = new HashSet<Etkinlikler>();
        }

        [DataMember]
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kid { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        [StringLength(50, ErrorMessage = "Bu Alan İçin Ayrılan Karakter Sayısını(50) Aştınız.Lütfen Düzenleyiniz!")]
        public string KAd { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        [StringLength(50, ErrorMessage = "Bu Alan İçin Ayrılan Karakter Sayısını(50) Aştınız.Lütfen Düzenleyiniz!")]
        public string KSoyad { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        [StringLength(50, ErrorMessage = "Bu Alan İçin Ayrılan Karakter Sayısını(50) Aştınız.Lütfen Düzenleyiniz!")]
        public string KEmail { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        [StringLength(50, ErrorMessage = "Bu Alan İçin Ayrılan Karakter Sayısını(50) Aştınız.Lütfen Düzenleyiniz!")]
        //[DataType(DataType.Password)]
        public string KSifre { get; set; }


        public ICollection<Etkinlikler> Etkinlik { get; set; }
    }
}
