using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Headquarters { get; set; }

        [Required]
        public int Income { get; set; }

        [NotMapped]
        public virtual ICollection<Author> Authors { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Authors = new HashSet<Author>();
            Books = new HashSet<Book>();
        }

    }
}
