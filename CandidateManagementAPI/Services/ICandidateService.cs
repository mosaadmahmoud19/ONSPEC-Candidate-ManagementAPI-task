using CandidateManagementAPI.DTOs;

namespace CandidateManagementAPI.Services
{
    public interface ICandidateService
    {
        Task AddOrUpdateCandidateAsync(CandidateDto candidateDto);

    }
}
