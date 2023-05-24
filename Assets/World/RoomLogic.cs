using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLogic : MonoBehaviour
{
    public BoxCollider2D roomCollider;
    public GameObject doorsObject;
    public bool isCleared;
    private bool playerOverlaps;
    private GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        playerOverlaps = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOverlaps && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !isCleared)
        {
            isCleared = true;
            Destroy(door);
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOverlaps = true;
            if(!(isCleared) && !(door)) {
                door = Instantiate(doorsObject, new Vector3(roomCollider.transform.position[0], roomCollider.transform.position[1], 1), new Quaternion());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerOverlaps = false;
        }
    }
}
