var builder = DistributedApplication.CreateBuilder(args);

//// Backing Services
var postgres = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent); //// Projeyi durdursan dahi çalışmaya devam edecek.

var catalogDb = postgres.AddDatabase("catalogdb");

//// Projects
var catalog = builder
    .AddProject<Projects.Catalog>("catalog")
    .WithReference(catalogDb)
    .WaitFor(catalogDb);

builder.Build().Run();
