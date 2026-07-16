using System.ComponentModel;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);



var server = builder.AddProject<Projects.Crud_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();


var c = builder.Configuration.GetConnectionString("DefaultConnection");
var db = builder.AddPostgres("postgres");

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
