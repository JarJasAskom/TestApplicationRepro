using Microsoft.EntityFrameworkCore;

namespace MyApplication;

public class CsireCommunicationQuery : ICsireCommunicationQuery
{
    readonly IDbContextFactory<CsireContext>? mDbContextFactory;
    readonly ILogger<CsireCommunicationQuery>? mLogger;
    readonly CsireContext mCsireContext;


    public CsireCommunicationQuery(IDbContextFactory<CsireContext> aDbContextFactory, ILogger<CsireCommunicationQuery> aLogger)
    {
        mDbContextFactory = aDbContextFactory;
        mLogger = aLogger;
        mCsireContext = mDbContextFactory.CreateDbContext();
    }


    public void Dispose()
    {
        mCsireContext.Dispose();
    }


    public IQueryable<CsireRequest> GetRequests()
    {
            IQueryable<CsireRequest> queryable = mCsireContext.Requests
            .TagWith("Test")
            .AsNoTracking();
            return queryable;
    }


    public async Task Insert(List<CsireRequest> aRequests)
    {
        mCsireContext.Requests.AddRange(aRequests);
        await mCsireContext.SaveChangesAsync();
    }
}
