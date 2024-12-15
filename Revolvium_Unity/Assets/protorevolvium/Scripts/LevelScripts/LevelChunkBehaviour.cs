using GD;
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
    private levelRotationDirection rotationTurnDirection;
    [SerializeField]
    private ForwardOrBackwardRotationDirction rotationDirction;

    [SerializeField]
    private LevelController levelController;

    private IEnumerator coroutine;

    [SerializeField]
    private GameEvent startRotation, endRotation;

    private bool canRotate = true;

    private void Start() {
       
    }

    //https://discussions.unity.com/t/smooth-rotatearound/435587/7 04/12/2024
    IEnumerator RotateFunction(GameObject poll, Vector3 pivotPos, float degree, Vector3 rotationDirection) {
        float timeSinceStarted = 0f;
        Quaternion startRotation = transform.rotation;
        Vector3 startPosition = transform.position;
        while (true) {
            timeSinceStarted += Time.deltaTime * 0.5f;
            transform.RotateAround(pivotPos, rotationDirection, degree * Time.deltaTime);
            // If the object has arrived, stop the coroutine
            if (timeSinceStarted >= 0.45f) {
                transform.rotation = startRotation;
                transform.position = startPosition;
                transform.RotateAround(pivotPos, rotationDirection, degree);
                endRotation?.Raise();
                canRotate = true;
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    [ContextMenu("rotate")]
    public void rotate() {
        if (canRotate) {
            canRotate = false;
            startRotation?.Raise();
            rotationTurnDirection = levelController.currentRotationDirection;
            //transform.RotateAround(cubeCenter, rotationTurnDirection.dir, 90);
            coroutine = RotateFunction(gameObject, cubeCenter, 90*rotationDirction.Direction, rotationTurnDirection.dir);
            StartCoroutine(coroutine);
        }
    }

}
