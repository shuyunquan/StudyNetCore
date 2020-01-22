using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(100,MinimumLength =2)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
