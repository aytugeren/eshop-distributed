var builder = DistributedApplication.CreateBuilder(args);

//// Backing Services
var postgres = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent); //// Projeyi durdursan dahi çalışmaya devam edecek.

var catalogDb = postgres.AddDatabase("catalogdb");
var cache = builder
    .AddRedis("cache")
    .WithRedisInsight()
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);
 
//// Projects
var catalog = builder
    .AddProject<Projects.Catalog>("catalog")
    .WithReference(catalogDb)
    .WaitFor(catalogDb);

builder.AddProject<Projects.Basket>("basket")
    .WithReference(cache)
    .WithReference(catalog)
    .WaitFor(cache);

builder.Build().Run();
