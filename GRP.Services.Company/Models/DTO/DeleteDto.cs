using GRP.Core.Interfaces;

namespace GRP.Services.Company.Models.DTO
{
    public record DeleteDto:IDTO
    {
        public Guid Id { get; set; }
        public Guid? UpdatedUserId { get; set; }

    }
}
