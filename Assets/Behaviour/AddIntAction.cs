using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Add Int", story: "Add [Amount] To [Variable]", category: "Action", id: "790a1955ab7bb8d3d5b3ee787e994229")]
public partial class AddIntAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Amount;
    [SerializeReference] public BlackboardVariable<int> Variable;
    protected override Status OnStart()
    {
        if (Variable == null)
        {
            return Status.Failure;
        }
        Variable.Value += Amount.Value;
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

