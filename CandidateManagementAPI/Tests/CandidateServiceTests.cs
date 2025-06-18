using AutoMapper;
using CandidateManagementAPI.DTOs;
using CandidateManagementAPI.Models;
using CandidateManagementAPI.Repositories;
using CandidateManagementAPI.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace CandidateManagementAPI.Tests
{
    public class CandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _repoMock;
        private readonly Mock<IMemoryCache> _cacheMock;

        private readonly IMapper _mapper;
        private readonly CandidateService _service;

        public CandidateServiceTests()
        {
            _repoMock = new Mock<ICandidateRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CandidateDto, Candidate>();
            });
            _mapper = config.CreateMapper();

            _service = new CandidateService(_repoMock.Object, _mapper, _cacheMock.Object);
        }

        [Fact]
        public async Task AddOrUpdateCandidateAsync_Should_Add_New_If_Not_Exists()
        {
            // Arrange
            var dto = new CandidateDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com"
            };

            _repoMock.Setup(r => r.GetByEmailAsync(dto.Email)).ReturnsAsync((Candidate)null);

            // Act
            await _service.AddOrUpdateCandidateAsync(dto);

            // Assert
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Candidate>()), Times.Once);
            _repoMock.Verify(r => r.UpdateAsync(It.IsAny<Candidate>()), Times.Never);
            _repoMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task AddOrUpdateCandidateAsync_Should_Update_If_Exists()
        {
            // Arrange
            var dto = new CandidateDto
            {
                FirstName = "Updated",
                LastName = "User",
                Email = "existing@example.com"
            };

            var existing = new Candidate { Email = "existing@example.com" };

            _repoMock.Setup(r => r.GetByEmailAsync(dto.Email)).ReturnsAsync(existing);

            // Act
            await _service.AddOrUpdateCandidateAsync(dto);

            // Assert
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Candidate>()), Times.Never);
            _repoMock.Verify(r => r.UpdateAsync(existing), Times.Once);
            _repoMock.Verify(r => r.SaveAsync(), Times.Once);
        }
    
}
}
