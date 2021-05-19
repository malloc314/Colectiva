using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PseudoProbableSequenceDto : IMap
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public byte First { get; set; }
        public byte Second { get; set; }
        public byte Thrid { get; set; }
        public byte Fourth { get; set; }
        public byte Fifth { get; set; }
        public byte Sixth { get; set; }
        public byte Seventh { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PseudoProbableSequence, PseudoProbableSequenceDto>();
            profile.CreateMap<PseudoProbableSequenceDto, PseudoProbableSequence>();
        }
    }
}
