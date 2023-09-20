using MyStore.NewFolder;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class ShipperModel
    {

        public int Shipperid { get; set; }

        [Required]
        [MinLength(5)]
        public string Companyname { get; set; } 

        [Required]
        [Phone]
        public string Phone { get; set; } 


    }
}
