using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  LEVEL CHUNK CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */
public class LevelChunkBehaviour : MonoBehaviour
{
    private Vector3 cubeCenter = new Vector3(1, 1, 1);
    [SerializeField]
    private levelRotationDirection rotateDirection;

    [SerializeField]
    private LevelController levelController;

    private void Start() {
        if (levelController.GetCreationSettings().w % 2 == 0)
            cubeCenter.x = 0.5f;
        if (levelController.GetCreationSettings().h % 2 == 0)
            cubeCenter.y = 0.5f;
        if (levelController.GetCreationSettings().d % 2 == 0)
            cubeCenter.z = 0.5f;
    }

    [ContextMenu("rotate")]
    public void rotate()
    {
        rotateDirection = levelController.currentRotationDirection;
        transform.RotateAround(cubeCenter, rotateDirection.dir, 90);
    }

}
