namespace Upnext.Application.Output;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}