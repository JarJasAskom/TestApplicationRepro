using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using MyApplication;
using MyApplication.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();
builder.Services.AddDataGridEntityFrameworkAdapter();


//builder.Services.AddDbContextFactory<CsireContext>(options => options
//    .UseSqlite("Data Source=csire.db", o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
//    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

string csireModelConnectionString = builder.Configuration.GetValue<string>("ConnectionString") ?? "";

builder.Services.AddDbContextFactory<CsireContext>(options => options
    .UseSqlServer(csireModelConnectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));


builder.Services.AddTransient<ICsireCommunicationQuery, CsireCommunicationQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
//}



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var csireContext = services.GetRequiredService<CsireContext>();
    //csireContext.Database.EnsureDeleted();
    csireContext.Database.EnsureCreated();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
