using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Mvc_Filters.Models
{
    public class Kullanici
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)/*otomatik id*/]
        public int Id { get; set; }

        [Required,StringLength(30)]
        public string Ad { get; set; }

        [Required, StringLength(30)]
        public string SoyAd { get; set; }

        [Required, StringLength(20)]
        public string KullaniciAdi { get; set; }

        [Required, StringLength(15)]
        public string Sifre { get; set; }


    }
}