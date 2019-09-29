using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModels
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal Price { get; set; }
    }
}
