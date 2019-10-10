using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Address1 { get; set; }
        public string Url { get; set; }
        public int? Status { get; set; }
    }
}
