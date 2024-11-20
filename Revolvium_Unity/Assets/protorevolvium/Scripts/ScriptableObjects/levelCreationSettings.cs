using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RUB/level/creationSettings", fileName = "LevelData")]
public class levelCreationSettings : ScriptableObject
{
    [SerializeField]
    public int w = 1, h = 1, d = 1; // width, height, and depth of level
    [SerializeField]
    public int blockWidth; // only width since blocks should fit into cubes, therefore the width, height, and depth would be the same

}
