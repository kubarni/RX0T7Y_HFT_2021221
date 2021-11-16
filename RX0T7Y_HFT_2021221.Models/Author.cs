using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }

    }
}
