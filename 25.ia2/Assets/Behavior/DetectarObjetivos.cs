using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetectarObjetivos", story: "Ver si [Agente] detecta al [objetivo]", category: "Action", id: "bec64270dcba24b3f866abc0daa2b223")]
public partial class DetectarObjetivosAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agente;
    [SerializeReference] public BlackboardVariable<GameObject> Objetivo;
    NavMeshAgent agente;
    Sensor sensor;

    protected override Status OnStart()
    {
        agente = Agente.Value.GetComponent<NavMeshAgent>();
        sensor = Agente.Value.GetComponent<Sensor>();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Objetivo.Value = sensor.GetClosestGameObject("Player");
        return Objetivo.Value == null ? Status.Running : Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

