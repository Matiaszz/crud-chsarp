using System.ComponentModel;

var builder = DistributedApplication.CreateBuilder(args);



var server = builder.AddProject<Projects.Crud_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();


var post = builder.AddPostgres("postgres");

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
