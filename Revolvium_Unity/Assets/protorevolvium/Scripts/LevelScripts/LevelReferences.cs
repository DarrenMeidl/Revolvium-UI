using UnityEngine;

/*
 *  LEVEL CONTROLLER - STARTED BY AND WRITTEN BY RUBY
 */

public class LevelReferences : MonoBehaviour
{
    [SerializeField]
    private Transform levelChunkFinder;

    [SerializeField]
    private levelCreationSettings creationSettings;

    public levelCreationSettings GetCreationSettings() { return creationSettings; }

    public levelRotationDirection currentRotationDirection;
}
