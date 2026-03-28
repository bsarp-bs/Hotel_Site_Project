using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.DtoLayer
{
    public class RoomDTO
    {
        [Required(ErrorMessage ="Oda Numarası Girmelisiniz")]
        public string No { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage = "Oda Fiyatı Girmelisiniz")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Yatak Sayısı Girmelisiniz")]
        public int BedCount { get; set; }
        public string Desc { get; set; }
    }
}
