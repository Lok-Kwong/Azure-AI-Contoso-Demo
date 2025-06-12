using AgentWorkshop.Client;
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddUserSecrets<Program>();

var configuration = builder.Build();

string apiDeploymentName = configuration["Azure:ModelName"] ?? throw new InvalidOperationException("Azure:ModelName is not set in the configuration.");
string projectConnectionString = configuration.GetConnectionString("AiAgentService") ?? throw new InvalidOperationException("ConnectionStrings:AiAgentService is not set in the configuration.");

AIProjectClient projectClient = new(projectConnectionString, new DefaultAzureCredential());

// Each one changes the instructions and adds a tool
await using AIAgent agent = new FunctionCall(projectClient, apiDeploymentName);
// FileSearch
// CodeInterpreter
await agent.RunAsync();
