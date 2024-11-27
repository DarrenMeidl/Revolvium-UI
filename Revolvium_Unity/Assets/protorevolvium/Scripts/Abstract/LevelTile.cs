using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  Level Tile Abstract Class - STARTED BY AND WRITTEN BY RUBY
 */

public abstract class LevelTile : MonoBehaviour 
{
    [SerializeField]
    private BoxCollider area;

    [SerializeField]
    private bool needsCorrectOrientation = true;
    [SerializeField]
    private Transform transform;

    [SerializeField, ReadOnly]
    private bool canInterract = false;

    private GameObject collider;

    public bool isCorrectlyOrientated()
    {
        return transform.up.y == 1 || !needsCorrectOrientation;
    }
    protected abstract void interact(GameObject player);

    public void interractKeyPressed(InputAction.CallbackContext value) {
        if (canInterract) {
            interact(collider);
            canInterract = false;
        }
    }
     
    private void OnTriggerEnter(Collider other)
    {//                                                                       
       if(other.tag == "player" && isCorrectlyOrientated())
        {
            canInterract = true;
            collider = other.gameObject;
        } 
    }
    private void OnTriggerExit(Collider other) {
        canInterract = false;
    }

}
