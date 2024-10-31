
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
