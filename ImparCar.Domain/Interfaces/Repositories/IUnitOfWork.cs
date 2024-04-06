namespace ImparCar.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork<TEntity> : IDisposable
        where TEntity : class
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
        IBaseRepository<TEntity> BaseRepository { get; }
        ICarRepository CarRepository { get; }
        IPhotoRepository PhotoRepository { get; }

    }
}
