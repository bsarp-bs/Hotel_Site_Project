using System;
using System.Collections.Generic;
using System.Text;

namespace API.EntityLayer.Concrete
{
    public class ContactCategory
    {
        public int ContactCategoryID { get; set; }

        public string? CategoryName { get; set; }

        public List<Contact>? Contacts { get; set; }
    }
}
