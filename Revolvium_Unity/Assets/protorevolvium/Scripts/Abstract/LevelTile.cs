using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  Level Tile Abstract Class - STARTED BY AND WRITTEN BY RUBY
 */

public abstract class LevelTile : MonoBehaviour 
{
    [SerializeField, Title("References")]
    private BoxCollider area;

    [SerializeField, Title("Attributes")]
    private bool needsCorrectOrientation = true;

    [SerializeField, ReadOnly, Title("Debugging")]
    private bool canInterract = false;

    private GameObject GameObjectCollidedWith;

    public bool isCorrectlyOrientated()
    {
        return transform.up.y == 1 || !needsCorrectOrientation;
    }
    protected abstract void interact(GameObject player);

    public void interractKeyPressed(InputAction.CallbackContext value) {
        if (canInterract) {
            interact(GameObjectCollidedWith);
            canInterract = false;
        }
    }
     
    private void OnTriggerEnter(Collider other)
    {//                                                                       
       if(other.tag == "player" && isCorrectlyOrientated())
        {
            canInterract = true;
            GameObjectCollidedWith = other.gameObject;
        } 
    }
    private void OnTriggerExit(Collider other) {
        canInterract = false;
    }

    public void Interact_Enabled() {
        canInterract = true;
    }
    public void Interact_Disabled() {
        canInterract = false;
    }

}
