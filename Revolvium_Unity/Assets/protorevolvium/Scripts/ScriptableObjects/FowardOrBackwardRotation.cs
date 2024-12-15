using UnityEngine;
[CreateAssetMenu(fileName = "ForwardOrBackwardRotationDirction",
            menuName = "RUB/level/rotationDirection")]
public class ForwardOrBackwardRotationDirction : ScriptableObject
{
    [SerializeField]
    [Tooltip("Controls whether the level does a positive or negative move")]
    [Range(-1f, 1f)]
    public int Direction = 1;
}