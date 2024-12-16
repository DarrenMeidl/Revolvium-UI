using UnityEngine;

/*
 *  LEVEL CHUNK FINDER BEHAVIOUR - STARTED BY AND WRITTEN BY RUBY
 */
public class LevelChunkFinderBehaviour : MonoBehaviour
{
    [SerializeField]
    private levelRotationDirection rotateDirection;


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
