
namespace DomainModels
{
    public class Digchip
    {
        public virtual int Id { get; set; }

        public virtual string PartNumber { get; set; }

        public virtual string Category { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual string Company { get; set; }

        public virtual string Specifications { get; set; }

        public virtual string Features { get; set; }

        public virtual string Applications { get; set; }

        public virtual string Address { get; set; }

        public virtual string Url { get; set; }
    }
}
