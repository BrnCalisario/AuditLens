using Audit.Core;
using Audit.EntityFramework;
using ExampleApi.Models;
using ExampleApi.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    var connection = builder.Configuration.GetConnectionString("ExampleApiDbContext");

    builder.Services.AddDbContext<ExampleApiDbContext>(options => options
        .UseSqlServer(connection)
        .AddInterceptors(new AuditSaveChangesInterceptor())
    );

    Audit.Core.Configuration.Setup()
        .UseEntityFramework(config => config
            .AuditTypeMapper(t => typeof(AuditLog))
            .AuditEntityAction<AuditLog>((ev, entry, auditLog) =>
            {
                auditLog.TableName = entry.Table;
                auditLog.AuditData = entry.ToJson();
                auditLog.AuditDate = DateTime.Now;
                auditLog.AuditAction = entry.Action;
                auditLog.AuditUser = "System";
            })
        );

        // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}