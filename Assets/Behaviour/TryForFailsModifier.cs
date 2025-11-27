using System;
using Unity.Behavior;
using UnityEngine;
using Modifier = Unity.Behavior.Modifier;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Try For Fails", story: "Try [Number] of Fails", category: "Flow", id: "6b76ddd2d19c59f8ab9ba8f01cd5ae52")]
public partial class TryForFailsModifier : Modifier
{
    [SerializeReference] public BlackboardVariable<int> Number;
    internal int attemptCount = 0;

    protected override Status OnStart()
    {
        attemptCount = attemptCount > 0 ? attemptCount : 1;
        if (Child == null)
        {
            return Status.Failure;
        }

        var status = StartNode(Child);
        if (status == Status.Failure || status == Status.Success)
        {
            return Status.Running;
        }

        return Status.Waiting;
    }

    protected override Status OnUpdate()
    {
        if (attemptCount >= Number.Value)
        {
            attemptCount = 0;
            Debug.Log("Out");
            return Status.Failure;
        }
        Status status = Child.CurrentStatus;
        if (status == Status.Failure)
        {
            attemptCount++;
            Debug.Log($"Failed attempt {attemptCount}!");
            return Status.Running;
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

