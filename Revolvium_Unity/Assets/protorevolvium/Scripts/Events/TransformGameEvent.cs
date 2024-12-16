using UnityEngine;

/*
 *  Transform GameEvent - STARTED BY AND WRITTEN BY RUBY
 *  Based on game events given in class, located in the GD folder
 */

namespace GD
{
    [CreateAssetMenu(fileName = "TransformGameEvent",
    menuName = "RUB/Patterns/Events/Transform")]
    public class TransformGameEvent : BaseGameEvent<Transform>
    { }
}