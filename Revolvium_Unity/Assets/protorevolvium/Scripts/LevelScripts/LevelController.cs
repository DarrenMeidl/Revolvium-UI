using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  LEVEL CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private Transform levelChunkFinder;

    private float delay = 0f; // delay is used between turns so that the chunk locator can activate and unactivate 
    [SerializeField]
    [Tooltip("the time between when inputs can be pressed")]
    private float defaultDelay = 1f; // default dealy used in between presses


    [SerializeField]
    private List<levelRotationDirection> rotationDirections = new List<levelRotationDirection>();

    public levelRotationDirection currentRotationDirection;


    [SerializeField]
    private bool canRotate;

    // will need to be improved
    [SerializeField, Tooltip("is true if the dimensions of the cube are even.")]
    private bool evenDimensions = false;


    // these 2 functions could be made into one, using canRotate = !canRotate and making the event a toggle rather than an enable/disable
    public void enableRotation()
    {
        canRotate = true;
    }
    public void disableRotation()
    {
        canRotate = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRotationDirection = rotationDirections[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            if (delay <= 0f )
                levelChunkFinder.gameObject.SetActive(false);
        }
        else if(canRotate){ // turn comments do not follow cube notation properly, eg L TURN is actually L', yet R TURN is R and not R' (if you don't get what any of that meant it is fine)
            if (Input.GetKeyDown(KeyCode.Alpha1)) //L TURN
            {
                startRotate(new Vector3(-1, 0, 0), new Vector3(0, 0, 0), 0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && !evenDimensions) //M TURN
            {
                startRotate(new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) //R TURN
            {
                startRotate(new Vector3(1, 0, 0), new Vector3(0, 0, 0), 0);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4)) //B TURN
            {
                startRotate(new Vector3(0, 0, 1), new Vector3(0, 90, 0), 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && !evenDimensions) //S TURN
            {
                startRotate(new Vector3(0, 0, 0), new Vector3(0, 90, 0), 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6)) //F TURN
            {
                startRotate(new Vector3(0, 0, -1), new Vector3(0, 90, 0), 1);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha7)) //U TURN
            {
                startRotate(new Vector3(0, 1, 0), new Vector3(0, 0, 90), 2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8) && !evenDimensions) //E TURN
            {
                startRotate(new Vector3(0, 0, 0), new Vector3(0, 0, 90), 2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9)) //D TURN
            {
                startRotate(new Vector3(0, -1, 0), new Vector3(0, 0, 90), 2);
            }
        }
    }


    private void startRotate(Vector3 pos, Vector3 dir, int rotateDir = 0)
    {
        delay = defaultDelay;

        currentRotationDirection = rotationDirections[rotateDir];

        levelChunkFinder.position = pos;
        levelChunkFinder.eulerAngles = dir;
        levelChunkFinder.gameObject.SetActive(true);
    }
}
