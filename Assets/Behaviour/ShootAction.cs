using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoot", story: "[Agent] Shoots at [Target] a [Bullet]", category: "Custom Action", id: "ab194ba15235c0389e30eb025d0fb6e5")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Bullet;
    public BlackboardVariable<float> BulletSpeed = new BlackboardVariable<float>(10f);

    protected override Status OnStart()
    {
        GameObject bulletInstance = GameObject.Instantiate(Bullet.Value, Agent.Value.transform.position, Quaternion.identity);
        if (bulletInstance.TryGetComponent(out Rigidbody rb))
        {
            Vector3 direction = Target.Value.transform.position - Agent.Value.transform.position;
            rb.AddForce(direction.normalized * BulletSpeed, ForceMode.Impulse);
        }

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

