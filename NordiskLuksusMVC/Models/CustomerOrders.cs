using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordiskLuksusMVC.Models{

    public class CustomerOrder{
        [Key]
        public int ID { get; set; }

        public string AuthorName { get; set; }

        public string Title{ get; set; }

        public string CustomerOrderText { get; set; }

        [ForeignKey("ProductID")]
        public int? ProductID {get; set;}
        public Product Product {get; set;}
       
    }
}