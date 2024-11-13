
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  LEVEL CHUNK FINDER BEHAVIOUR - STARTED BY AND WRITTEN BY RUBY
 */
public class LevelChunkFinderBehaviour : MonoBehaviour
{
    [SerializeField]
    private levelRotationDirection rotateDirection;


    [ContextMenu("triggerOn")]
    private void trigger()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "levelChunk")
        {
            LevelChunkBehaviour levelChunk = other.gameObject.GetComponent<LevelChunkBehaviour>();
            if (levelChunk != null)
            {
                levelChunk.rotate();
            }
        }
    }
}
