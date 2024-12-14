using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "Vector3GameEvent",
    menuName = "RUB/Patterns/Events/Transform")]
    public class TransformGameEvent : BaseGameEvent<Transform>
    { }
}