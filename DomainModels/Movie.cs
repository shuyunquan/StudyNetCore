using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Movie
    {
        public int ID { get; set; }
        [StringLength(20)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [StringLength(20)]
        public string Genre { get; set; }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal Price { get; set; }
    }
}
