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
        public int Sn { get; set; }
        public byte First { get; set; }
        public byte Second { get; set; }
        public byte Thrid { get; set; }
        public byte Fourth { get; set; }
        public byte Fifth { get; set; }
        public byte Sixth { get; set; }
        public byte Seventh { get; set; }
    }
}
