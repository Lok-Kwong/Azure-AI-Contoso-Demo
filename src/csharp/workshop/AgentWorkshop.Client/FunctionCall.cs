using Azure.AI.Projects;

namespace AgentWorkshop.Client;

public class FunctionCall(AIProjectClient client, string modelName)
    : AIAgent(client, modelName)
{
    protected override string InstructionsFileName => "function_calling.txt";
}
