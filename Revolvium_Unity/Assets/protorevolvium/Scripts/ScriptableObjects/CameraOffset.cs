
using UnityEngine;


[CreateAssetMenu(fileName = "LevelXCameraOffsets",
            menuName = "RUB/level/camera/offsets")]
public class CameraOffset : ScriptableObject {
    [SerializeField]
    public Vector3 playerOffset = new Vector3(0,0,0);
    [SerializeField]
    public Vector3 levelOffset = new Vector3(0, 0, 0);
}
