namespace MyApplication;

public interface ICsireCommunicationQuery : IDisposable
{
    IQueryable<CsireRequest> GetRequests();
}
