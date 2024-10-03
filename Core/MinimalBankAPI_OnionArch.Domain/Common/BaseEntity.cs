namespace MinimalBankAPI_OnionArch.Domain.Common
{
    public class BaseEntity : IEntityTimestamps, IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
