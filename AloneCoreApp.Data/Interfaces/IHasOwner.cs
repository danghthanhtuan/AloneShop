namespace AloneCoreApp.Data.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwnerId { get; set; }
    }
}