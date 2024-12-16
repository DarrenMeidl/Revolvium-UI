using GD;
using GD.Audio;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  Rotation Selection behaviour - STARTED BY AND WRITTEN BY RUBY
 */
public class RotationSelectionController : MonoBehaviour {
    [SerializeField, Title("References")]
    private LevelReferences levelController;
    [SerializeField]
    private levelCreationSettings creationSettings;
    [SerializeField]
    private LevelSelectorBoundaries levelSelectorBoundaries;
    [SerializeField]
    private BoxCollider player;
    [SerializeField]
    private ForwardOrBackwardRotationDirction rotationDirction;

    [SerializeField]
    private List<SelectorBehaviour> selectors = new List<SelectorBehaviour>();

    [SerializeField, Title("Events")]
    private GameEvent disableRotationEvent;

    [SerializeField, Title("Sounds")]
    private AudioClip RotationSound;

    [SerializeField, ReadOnly, Title("Debugging")]
    private int currentSelector = 0;
    [SerializeField, ReadOnly]
    private bool canRotate;

    private Vector3 selectorMoveDirection = new Vector3(1, 1, 1);

    private int blockSize;

    private float delay = 0f; // delay is used between turns so that the chunk locator can activate and unactivate 


    public void enableRotation() {
        selectors[currentSelector].enableHighLight();
        canRotate = true;
        selectorMoveDirection = new Vector3(1,1,1);
    }
    public void disableRotation() {
        selectors[currentSelector].disableHighLight();
        canRotate = false;
        delay = 1.5f;
    }

    IEnumerator DisableAfterRotationStart(GameObject poll) {
        yield return null;
        poll.SetActive(false);
        selectors[currentSelector].disableSelector();
        yield break;
    }
    public void StartRotation() {
        StartCoroutine(DisableAfterRotationStart(gameObject));
    }


    public void CamMoved(Vector3 pos) {
        selectorMoveDirection.z = (pos.z < 0) ? -1 : 1;
        selectorMoveDirection.x = (pos.x < 0) ? -1 : 1;
    }

    public void ToggleRotationDirection(int dir) {
        rotationDirction.Direction = dir;
    }

    // Start is called before the first frame update
    void Start() {
        rotationDirction.Direction = 1;
        foreach (var selector in selectors) {
            selector.disableHighLight();
        }
        blockSize = creationSettings.blockWidth;
    }

    public void Rotate(InputAction.CallbackContext value) {
        if (value.started) {

            BoxCollider selector = selectors[currentSelector].gameObject.GetComponent<BoxCollider>();

            if (player.bounds.Intersects(selector.bounds)) {
                return;
            }
            else if (value.started && canRotate && delay <= 0) {
                AudioManager.Instance.PlaySound(RotationSound, GD.Types.AudioMixerGroupName.SFX);
                RumbleManager.Instance.Rumble(0.5f, 1f, 0.8f);
                levelController.currentRotationDirection = selectors[currentSelector].selectorMoveDir;
                selectors[currentSelector].enableSelector();
                delay = 1;
            }
        }
    }

    public void MoveSelectorRight(InputAction.CallbackContext value) {
        if (value.started && canRotate && delay <= 0) 
            moveSelector(1);
    }
    public void MoveSelectorLeftt(InputAction.CallbackContext value) {
        if (value.started && canRotate && delay <= 0) 
            moveSelector(-1);
    }

    public void ToggleSelectorDirectionUp(InputAction.CallbackContext value) {
        if (value.started && canRotate && delay <= 0) {
            selectors[currentSelector].disableHighLight();
            currentSelector += 1;
            if (currentSelector == selectors.Count)
                currentSelector = 0;
                selectors[currentSelector].enableHighLight();
        }
    }
    public void ToggleSelectorDirectionDown(InputAction.CallbackContext value) {
        if (value.started && canRotate && delay <= 0) {
            selectors[currentSelector].disableHighLight();
            currentSelector -= 1;
            if (currentSelector < 0)
                currentSelector = selectors.Count - 1;
            selectors[currentSelector].enableHighLight();
        }
    }


    public void DisableRotation(InputAction.CallbackContext value) {
        if (value.started && canRotate && delay <= 0) 
            disableRotationEvent?.Raise();
    }



    private void FixedUpdate() {
        if (canRotate) {
            if (delay > 0) {
                delay -= 0.5f;
            }
            else {
                selectors[currentSelector].disableSelector();


            }
        }
    }

    private void moveSelector(int dir) {
        dir = (int)math.sign(dir);
        Vector3 moveDir = selectors[currentSelector].selectorMoveDir.dir;
        Vector3 currentPosition = selectors[currentSelector].gameObject.transform.position;

        float newX = currentPosition.x + (blockSize * moveDir.x * dir * selectorMoveDirection.z);
        float newY = currentPosition.y - (blockSize * moveDir.y * dir);
        float newZ = currentPosition.z + (blockSize * moveDir.z * dir * selectorMoveDirection.x);

        //Debug.Log(newX);
        //Debug.Log((newX < levelSelectorBoundaries.minX));
        //Debug.Log((newX > levelSelectorBoundaries.maxX));

        //newX = ((newX>levelSelectorBoundaries.maxX) || (newX < levelSelectorBoundaries.minX)) ? currentPosition.x : newX;
        //newY = ((newY>levelSelectorBoundaries.maxY) || (newY < levelSelectorBoundaries.minY)) ? currentPosition.y : newY;
        //newZ = ((newZ>levelSelectorBoundaries.maxZ) || (newZ < levelSelectorBoundaries.minZ)) ? currentPosition.z : newZ;

        Vector3 newPosition = new Vector3(newX, newY, newZ);
        delay = 1;
        selectors[currentSelector].gameObject.transform.position = newPosition;

    }
}
