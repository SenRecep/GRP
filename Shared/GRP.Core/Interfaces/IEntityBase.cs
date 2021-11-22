namespace GRP.Core.Interfaces;

public interface IEntityBase
{
    Guid Id { get; set; }
    DateTime CreatedTime { get; set; }
    DateTime? UpdatedTime { get; set; }
    Guid CreatedUserId { get; set; }
    Guid? UpdatedUserId { get; set; }
    bool IsDeleted { get; set; }
}
