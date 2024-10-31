using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  LEVEL CHUNK CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */
public class LevelChunkBehaviour : MonoBehaviour
{
    private Vector3 cubeCenter = new Vector3(0, 0, 0);
    [SerializeField]
    private levelRotationDirection rotateDirection;

    [SerializeField]
    private LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    [ContextMenu("rotate")]
    public void rotate()
    {
        rotateDirection = levelController.currentRotationDirection;
        transform.RotateAround(cubeCenter, rotateDirection.dir, 90);
    }

}
