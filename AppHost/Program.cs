var builder = DistributedApplication.CreateBuilder(args);

// add projects and cloud-native backing services here

builder.AddProject<Projects.Catalog>("catalog");

// add projects and cloud-native backing services here

builder.Build().Run();
