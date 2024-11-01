using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GameObjectEsNull", story: "[gameObject] es null?", category: "Action", id: "1ef6109739c066f83157b4eb4cee52b6")]
public partial class GameObjectEsNullAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> gameObject;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return gameObject.Value == null ? Status.Success : Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

