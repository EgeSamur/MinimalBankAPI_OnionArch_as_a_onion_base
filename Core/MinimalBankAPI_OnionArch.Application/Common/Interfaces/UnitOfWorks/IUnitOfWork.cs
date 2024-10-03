namespace MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveChangesAsync();
    }
}
