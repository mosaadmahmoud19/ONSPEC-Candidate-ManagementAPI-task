using System.ComponentModel.DataAnnotations;

namespace CandidateManagementAPI.DTOs
{
    public class CandidateDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PreferredCallTime { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? Comment { get; set; }
    }
}
