using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreationBehaviour : MonoBehaviour
{
    [SerializeField]
    private int w, h, d; // width, height, and depth of level
    [SerializeField]
    private List<Transform> blocks;
    [SerializeField]
    private int blockWidth; // only width since blocks should fit into cubes, therefore the width, height, and depth would be the same

    [ContextMenu("Sort Level Blocks")]
    void sortLevelBlocks()
    {
        if(blocks.Count == w*h*d) {
            int currentBlock = 0;

            int wEnd = ((int)(w / 2));
            int hEnd = ((int)(h / 2));
            int dEnd = ((int)(d / 2));

            for (int x = -wEnd; x < wEnd; x++) {
                for (int y = -hEnd; y < hEnd; y++) {
                    for (int z = -dEnd; z < dEnd; z++) {
                        blocks[currentBlock].position = new Vector3(x * blockWidth, y * blockWidth, z * blockWidth);
                        currentBlock++;
                    }
                }
            }        
        }
        else
        {
            Debug.Log($"There are not the correct amount of level blocks in the list. Expected: {w*h*d}. Actual: {blocks.Count}");
        }
    }

}
