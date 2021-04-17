using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HistoricalSequenceService : IHistoricalSequenceService
    {
        private readonly IHistoricalSequenceRepository _repository;
        private readonly IMapper _mapper;

        public HistoricalSequenceService(IHistoricalSequenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<HistoricalSequenceDto> GetAllHistoricalSequences()
        {
            var sequences = _repository.GetAll();
            return _mapper.Map<IEnumerable<HistoricalSequenceDto>>(sequences);
        }

        public HistoricalSequenceDto GetHistoricalSequenceById(int sn)
        {
            var sequence = _repository.GetById(sn);

            return _mapper.Map<HistoricalSequenceDto>(sequence);
        }
    }
}
