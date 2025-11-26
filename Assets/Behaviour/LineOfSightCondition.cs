using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "LineOfSight", story: "[Agent] has line of sight of [GameObj]", category: "Custom Category", id: "bdd5fb1849708d997b4857c1494ce2e2")]
public partial class LineOfSightCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> GameObj;

    public override bool IsTrue()
    {
        Ray ray = new Ray(Agent.Value.transform.position, GameObj.Value.transform.position - Agent.Value.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == GameObj.Value)
            {
                return true;
            }
        }

        return false;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
