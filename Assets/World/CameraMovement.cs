using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public BoxCollider2D roomCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.SetPositionAndRotation(new Vector3(roomCollider.transform.position[0], roomCollider.transform.position[1]-0.5f, -10), Camera.main.transform.rotation);
        }
    }
}
