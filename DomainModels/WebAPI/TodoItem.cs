using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class TodoItem
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
