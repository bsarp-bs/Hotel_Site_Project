using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WEB_UI.UI_DTO.DutyDTOs
{
    public class ViewDutyDto
    {
        public int DutyID { get; set; }
        public string? Icon { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
    }
}




