using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SosyalEtkinlikWEB.Entities
{
    public class Satis
    {
        [DataMember]
        [Column("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sid { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("Eid")]
        public int Eid { get; set; }
        public Etkinlikler Etkinlikler { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SOdenecekTutar { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        [StringLength(50, ErrorMessage = "Bu Alan İçin Ayrılan Karakter Sayısını(50) Aştınız.Lütfen Düzenleyiniz!")]
        public string KEmail { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz!")]
        public int SBiletAdeti { get; set; }
    }
}