
using UnityEngine;


[CreateAssetMenu(fileName = "LevelXYZBoundries",
            menuName = "RUB/level/Boundaries")]
public class LevelSelectorBoundaries : ScriptableObject {
    [SerializeField]
    public int minX = -1, minY = -1, minZ = -1;
    [SerializeField]
    public int maxX = 1, maxY = 1, maxZ = 1;
}
