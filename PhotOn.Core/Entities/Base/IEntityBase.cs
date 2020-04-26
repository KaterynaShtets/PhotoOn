namespace PhotOn.Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
        bool IsDeleted { get; set; }
    }
}
