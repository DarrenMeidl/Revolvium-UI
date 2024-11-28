using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  LEVEL CHUNK CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */
public class LevelChunkBehaviour : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private Vector3 cubeCenter = new Vector3(1, 1, 1);

    public void SetCenter(Vector3 center) {
        cubeCenter = center;
    }

    [SerializeField]
    private levelRotationDirection rotateDirection;

    [SerializeField]
    private LevelController levelController;

    private void Start() {
       
    }

    [ContextMenu("rotate")]
    public void rotate()
    {
        rotateDirection = levelController.currentRotationDirection;
        transform.RotateAround(cubeCenter, rotateDirection.dir, 90);
    }

}
