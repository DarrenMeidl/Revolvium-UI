using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  LEVEL CREATION BEHAVIOUR - STARTED BY AND WRITTEN BY RUBY
 */
public class LevelCreationBehaviour : MonoBehaviour
{
    [SerializeField]
    private levelCreationSettings creationSettings;
    [ReadOnly, SerializeField]
    private float offsetX, offsetY, offsetZ;
    [SerializeField]
    public List<Transform> blocks;

    private void Start()
    {
        sortLevelBlocks();
    }

    private void setOffsets() {
        offsetX = (creationSettings.w % 2 == 0) ? 0.5f : 0;
        offsetY = (creationSettings.h % 2 == 0) ? 0.5f : 0;
        offsetZ = (creationSettings.d % 2 == 0) ? 0.5f : 0;
    }



    [ContextMenu("Sort Level Blocks")]
    void sortLevelBlocks()
    {
        setOffsets();
        if(blocks.Count == creationSettings.w * creationSettings.h * creationSettings.d) {
            int currentBlock = 0;

            int wEnd = creationSettings.w;
            int hEnd = creationSettings.h;
            int dEnd = creationSettings.d;

            for (int x = 0; x < wEnd; x++) {
                for (int y = 0; y < hEnd; y++) {
                    for (int z =0; z < dEnd; z++) {
                        blocks[currentBlock].position = new Vector3(x * creationSettings.blockWidth + offsetX, y * creationSettings.blockWidth + offsetY, z * creationSettings.blockWidth + offsetZ);
                        Debug.Log(blocks[currentBlock].position);
                        currentBlock++;
                    }
                }
            }        
        }
        else
        {
            Debug.Log($"There are not the correct amount of level blocks in the list. Expected: {creationSettings.w *creationSettings.h *creationSettings.d}. Actual: {blocks.Count}");
        }
    }

}
