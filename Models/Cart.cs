using System.ComponentModel.DataAnnotations;

namespace EStore_MVC_.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; internal set; }
        public object Product { get; internal set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }

    }
}