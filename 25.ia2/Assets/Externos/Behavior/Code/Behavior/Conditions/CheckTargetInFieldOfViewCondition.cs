using System;
using UnityEngine;

namespace Unity.Behavior.Demo
{
    [Serializable]
    [Condition(
            name: "Check FoV",
            category: "Conditions",
            story: "[Origin] has [Target] in view below [Angle] degrees",
            id: "17f18739e880f2880a0c8b3df7c50061")]
    public class CheckTargetInFieldOfViewCondition : Condition
    {
        [SerializeReference] public BlackboardVariable<Transform> Origin;
        [SerializeReference] public BlackboardVariable<Transform> Target;
        [SerializeReference] public BlackboardVariable<float> Angle = new(90f);

        public override bool IsTrue()
        {
            if (Origin.Value == null || Target.Value == null)
            {
                return false;
            }

            float distance = Vector3.Distance(Origin.Value.position, Target.Value.position);
            var looking = IsLookingAtTarget(Origin, Target.Value.position, Angle);
            var inView = HasTargetInView(Origin.Value.position, Target);
            // Debug.Log($"looking {looking}, inView {inView}");
            return looking && inView;
        }

        private static bool IsLookingAtTarget(Transform origin, Vector3 targetPosition, float angle)
        {
            var forward = origin.forward;
            var toTarget = targetPosition - origin.position;
            var currentAngle = Vector3.Angle(forward, toTarget);
            return currentAngle < angle * 0.5f; // andlge is divided by 2 as it is angles in both direction.
        }

        private static bool HasTargetInView(Vector3 origin, Transform target)
        {
            // Elevo los puntos un poco para que el rayo no choque contra el piso
            var originAjustado = origin + Vector3.up;
            var targetAjustado = target.position + Vector3.up;
            if (Physics.Linecast(originAjustado, targetAjustado, out var t))
            {
                // Debug.Log($"si que hay linecast, {t.collider.gameObject.name}, {target.gameObject.name}");
                // Debug.Log($"{t.collider.gameObject.layer}, {target.gameObject.layer}");
                return t.collider.gameObject == target.gameObject;
            }

            // Debug.Log($"no linecast");
            return false;
        }
    }
}