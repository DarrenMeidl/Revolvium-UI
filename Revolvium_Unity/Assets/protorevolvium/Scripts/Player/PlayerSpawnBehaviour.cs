using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void Update() {
        player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.SetActive(false);
    }

}
