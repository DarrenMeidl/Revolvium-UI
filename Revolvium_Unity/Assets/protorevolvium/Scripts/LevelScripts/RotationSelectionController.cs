using GD;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotationSelectionController : MonoBehaviour {
    [SerializeField]
    private LevelController levelController;
    [SerializeField]
    private levelCreationSettings creationSettings;


    private int blockSize;

    private float delay = 0f; // delay is used between turns so that the chunk locator can activate and unactivate 

    [SerializeField]
    private List<SelectorBehaviour> selectors = new List<SelectorBehaviour>();

    [SerializeField, ReadOnly]
    private int currentSelector = 0;
    [SerializeField, ReadOnly]
    private bool canRotate;

    [SerializeField]
    private GameEvent disableRotationEvent;

    // these 2 functions could be made into one, using canRotate = !canRotate and making the event a toggle rather than an enable/disable
    public void enableRotation() {
        selectors[currentSelector].enableHighLight();
        canRotate = true;
    }
    public void disableRotation() {
        selectors[currentSelector].disableHighLight();
        canRotate = false;
        delay = 1.5f;
    }
    // Start is called before the first frame update
    void Start() {
        foreach (var selector in selectors) {
            selector.disableHighLight();
        }
        blockSize = creationSettings.blockWidth;
    }
    private void FixedUpdate() {
        if (canRotate) {
            if (delay > 0) {
                delay -= 0.5f;
            }
            else {
                selectors[currentSelector].disableSelector();
                if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    moveSelector(1);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    moveSelector(-1);
                }

                else if (Input.GetKeyDown(KeyCode.Space)) {
                    levelController.currentRotationDirection = selectors[currentSelector].selectorMoveDir;
                    selectors[currentSelector].enableSelector();
                }

                else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    selectors[currentSelector].disableHighLight();
                    currentSelector += 1;
                    if (currentSelector == selectors.Count)
                        currentSelector = 0;
                    selectors[currentSelector].enableHighLight();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    selectors[currentSelector].disableHighLight();
                    currentSelector -= 1;
                    if (currentSelector == 0)
                        currentSelector = selectors.Count - 1;
                    selectors[currentSelector].enableHighLight();
                }
                else if (Input.GetKeyDown(KeyCode.Escape)) {
                    disableRotationEvent?.Raise();
                }
            }
        }
    }

    private void moveSelector(int dir) {
        dir = (int)math.sign(dir);
        Vector3 moveDir = selectors[currentSelector].selectorMoveDir.dir;
        Vector3 currentPosition = selectors[currentSelector].gameObject.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x + (blockSize * moveDir.x * dir), currentPosition.y + (blockSize * moveDir.y * dir), currentPosition.z + (blockSize * moveDir.z * dir));
        delay = 1;
        selectors[currentSelector].gameObject.transform.position = newPosition;
    }
}
