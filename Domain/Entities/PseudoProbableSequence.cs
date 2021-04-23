using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("PseudoProbableSequences")]
    public class PseudoProbableSequence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Sn { get; set; }
        [Required]
        public byte First { get; set; }
        [Required]
        public byte Second { get; set; }
        [Required]
        public byte Thrid { get; set; }
        [Required]
        public byte Fourth { get; set; }
        [Required]
        public byte Fifth { get; set; }
        [Required]
        public byte Sixth { get; set; }
        [Required]
        public byte Seventh { get; set; }
    }
}
