using System.ComponentModel.DataAnnotations;

namespace WEB_UI.UI_DTO.GuestDTOs
{
    public class InsertGuestDto
    {
        [Required(ErrorMessage = "Misafir adi bos birakilamaz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kisi sayisi bos birakilamaz")]
        public int Count { get; set; }
    }
}
