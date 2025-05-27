using Azure.AI.Projects;

namespace AgentWorkshop.Client;

public class CodeInterpreter(AIProjectClient client, string modelName) : AIAgent(client, modelName)
{
    protected override string InstructionsFileName => "code_interpreter.txt";

    public override IEnumerable<ToolDefinition> IntialiseLabTools() =>
        [new CodeInterpreterToolDefinition()];
}
