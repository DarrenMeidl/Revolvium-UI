using UnityEngine;

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

    public bool isCorrectlyOrientated()
    {
        return transform.up.y == 1 || !needsCorrectOrientation;
    }
    protected abstract void interact(GameObject player);

    private void OnTriggerStay(Collider other)
    {//                                                                        change this
       if(other.tag == "player" && isCorrectlyOrientated() && Input.GetKeyDown(KeyCode.E))
        {
            interact(other.gameObject);
        } 
    }

}
