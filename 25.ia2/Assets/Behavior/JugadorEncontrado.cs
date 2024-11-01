using System;
using Unity.Behavior.GraphFramework;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/JugadorEncontrado")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "JugadorEncontrado", message: "[Agente] encontro al [Jugador]", category: "Events", id: "76dd804b00b3d4875c92ae16a66f4dd5")]
public partial class JugadorEncontrado : EventChannelBase
{
    public delegate void JugadorEncontradoEventHandler(GameObject Agente, GameObject Jugador);
    public event JugadorEncontradoEventHandler Event; 

    public void SendEventMessage(GameObject Agente, GameObject Jugador)
    {
        Event?.Invoke(Agente, Jugador);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> AgenteBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Agente = AgenteBlackboardVariable != null ? AgenteBlackboardVariable.Value : default(GameObject);

        BlackboardVariable<GameObject> JugadorBlackboardVariable = messageData[1] as BlackboardVariable<GameObject>;
        var Jugador = JugadorBlackboardVariable != null ? JugadorBlackboardVariable.Value : default(GameObject);

        Event?.Invoke(Agente, Jugador);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        JugadorEncontradoEventHandler del = (Agente, Jugador) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Agente;

            BlackboardVariable<GameObject> var1 = vars[1] as BlackboardVariable<GameObject>;
            if(var1 != null)
                var1.Value = Jugador;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as JugadorEncontradoEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as JugadorEncontradoEventHandler;
    }
}

