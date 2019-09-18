using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordiskLuksusMVC.Models{

    public class Product{
        [Key]
        public int ID { get; set; }

        public string ProductName{ get; set; }

        
        [ForeignKey("ProductID")]

        public ICollection<CustomerOrder> CustomerOrder { get; set; }
        
    }
}

//en annmeldelse kan kun ha en 
//Product, men en Product 
//kan ha flere annmeldelser