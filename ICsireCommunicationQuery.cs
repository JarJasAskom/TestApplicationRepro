namespace MyApplication;

public interface ICsireCommunicationQuery : IDisposable
{
    IQueryable<CsireRequest> GetRequests();
    Task Insert(List<CsireRequest> aRequests);  
}
