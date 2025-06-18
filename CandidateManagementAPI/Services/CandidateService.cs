using AutoMapper;
using CandidateManagementAPI.DTOs;
using CandidateManagementAPI.Models;
using CandidateManagementAPI.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace CandidateManagementAPI.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public CandidateService(ICandidateRepository repository, IMapper mapper, IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task AddOrUpdateCandidateAsync(CandidateDto dto)
        {
            string cacheKey = $"Candidate_{dto.Email.ToLower()}";

            if (!_cache.TryGetValue(cacheKey, out Candidate existing))
            {
                existing = await _repository.GetByEmailAsync(dto.Email);

                if (existing != null)
                {
                    _cache.Set(cacheKey, existing, TimeSpan.FromMinutes(10));
                }
            }

            Candidate finalCandidate;

            if (existing != null)
            {
                _mapper.Map(dto, existing);
                await _repository.UpdateAsync(existing);
                finalCandidate = existing;
            }
            else
            {
                var newCandidate = _mapper.Map<Candidate>(dto);
                await _repository.AddAsync(newCandidate);
                finalCandidate = newCandidate;
            }

            await _repository.SaveAsync();

            _cache.Set(cacheKey, finalCandidate, TimeSpan.FromMinutes(10));
        }
    }
}
