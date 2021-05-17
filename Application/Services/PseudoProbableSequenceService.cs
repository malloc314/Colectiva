using Application.Dto;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PseudoProbableSequenceService : IPseudoProbableSequenceService
    {
        private readonly IPseudoProbableSequenceRepository _repository;
        private readonly IMapper _mapper;

        public PseudoProbableSequenceService(IPseudoProbableSequenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PseudoProbableSequenceDto> DrawPseudoProbableSequences(PseudoProbableSequenceQuantity quantity)
        {
            var sequences = _repository.GetAll().ToList();

            var rand = new Random();

            var pseudoProbableSequences = new List<PseudoProbableSequence>();

            List<byte> first = new List<byte>();
            List<byte> second = new List<byte>();
            List<byte> thrid = new List<byte>();
            List<byte> fourth = new List<byte>();
            List<byte> fifth = new List<byte>();
            List<byte> sixth = new List<byte>();
            List<byte> seventh = new List<byte>();
            
            byte firstDraw = 0;
            byte secondDraw = 0;
            byte thridDraw = 0;
            byte fourthDraw = 0;
            byte fifthDraw = 0;
            byte sixthDraw = 0;
            byte seventhDraw = 0;


            foreach (var number in sequences)
            {
                first.Add(number.First);
                second.Add(number.Second);
                thrid.Add(number.Thrid);
                fourth.Add(number.Fourth);
                fifth.Add(number.Fifth);
                sixth.Add(number.Sixth);
                seventh.Add(number.Seventh);
            }

            // Temporary solution.
            for (int i = 1; i <= quantity.Qty; i++)
            {
                // Generate 5 random bytes between 1 and 50.
                firstDraw = first[rand.Next(1, 49)];
                secondDraw = second[rand.Next(1, 49)];
                if (firstDraw > secondDraw)
                    while (firstDraw > secondDraw)
                        secondDraw = second[rand.Next(1, 49)];

                thridDraw = thrid[rand.Next(1, 49)];
                if (secondDraw > thridDraw)
                    while (secondDraw > thridDraw)
                        thridDraw = thrid[rand.Next(1, 49)];

                fourthDraw = fourth[rand.Next(1, 49)];
                if (thridDraw > fourthDraw)
                    while (thridDraw > fourthDraw)
                        fourthDraw = fourth[rand.Next(1, 49)];

                fifthDraw = fifth[rand.Next(1, 49)];
                if (fourthDraw > fifthDraw)
                    while (fourthDraw > fifthDraw)
                        fifthDraw = fifth[rand.Next(1, 49)];

                // Generate 2 random bytes between 1 and 10.
                sixthDraw = sixth[rand.Next(1, 9)];
                seventhDraw = seventh[rand.Next(1, 9)];
                if (sixthDraw > seventhDraw)
                    while (sixthDraw > seventhDraw)
                        seventhDraw = seventh[rand.Next(1, 9)];

                var pseudoProbableSequence = new PseudoProbableSequence()
                {
                    First = firstDraw,
                    Second = secondDraw,
                    Thrid = thridDraw,
                    Fourth = fourthDraw,
                    Fifth = fifthDraw,
                    Sixth = sixthDraw,
                    Seventh = seventhDraw
                };

                pseudoProbableSequences.Add(pseudoProbableSequence);
            }

            return _mapper.Map<IEnumerable<PseudoProbableSequenceDto>>(pseudoProbableSequences);
        }

        public PseudoProbableSequenceDto PostPseudoProbableSequence(PseudoProbableSequenceDto dto, string userId)
        {
            var sequence = _mapper.Map<PseudoProbableSequence>(dto);
            
            sequence.UserId = userId;

            _repository.PostAll(sequence);

            return _mapper.Map<PseudoProbableSequenceDto>(sequence);
        }

        public IEnumerable<PseudoProbableSequenceDto> GetPseudoProbableSequences(string userId, bool isAdmin)
        {
            var pseudoSequences = _repository.GetAllPseudo(userId, isAdmin);
            return _mapper.Map<IEnumerable<PseudoProbableSequenceDto>>(pseudoSequences);
        }

        public PseudoProbableSequenceDto GetPseudoProbableSequenceById(int pseudoId)
        {
            var pseudoSequence = _repository.GetPseudoById(pseudoId);
            return _mapper.Map<PseudoProbableSequenceDto>(pseudoSequence);
        }

        public bool UserOwnsPseudoProbableSequence(int pseudoId, string userId)
        {
            var pseudoSequence = _repository.GetPseudoById(pseudoId);

            if (pseudoSequence is null)
            {
                return false;
            }

            if (pseudoSequence.UserId != userId)
            {
                return false;
            }

            return true;
        }

        public void DeletePseudoProbableSequence(int pseudoId)
        {
            var pseudoSequence = _repository.GetPseudoById(pseudoId);
            _repository.DeletePseudo(pseudoSequence);
        }
    }
}
