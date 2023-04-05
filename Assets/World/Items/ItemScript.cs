using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int item_id;
    public Sprite[] spriteArray;
    public BoxCollider2D itemCollider;
    public GameObject go;

    SpriteRenderer srenderer;
    bool can_pickup;
    
    // Start is called before the first frame update
    void Start()
    {
        can_pickup = false;
        srenderer = gameObject.GetComponent<SpriteRenderer>();
        srenderer.sprite = spriteArray[item_id];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e") && can_pickup)
        {
            Destroy(go);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            can_pickup = true;
            //todo: show pickup tag object while player hovering
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            can_pickup = false;
        }    
    }
}
