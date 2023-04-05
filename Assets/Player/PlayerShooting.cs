using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //bullet params
    public float delayInSeconds = 1.0f;
    public float range = 10.0f;
    public float speed = 10.0f;

    public GameObject bulletObject;
    public Rigidbody2D playerRb;

    bool canShoot = true;
    bool shooting = false;
    float x_dir = 0.0f;
    float y_dir = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot){
            if (Input.GetKey(KeyCode.UpArrow))
            {
                shooting = true;
                y_dir = 1;
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                shooting = true;
                y_dir = -1;
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                shooting = true;
                x_dir = -1;
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                shooting = true;
                x_dir = 1;
            }
            if(Mathf.Abs(x_dir) == 1.0f && Mathf.Abs(y_dir) == 1.0f) //todo: rework this?
            {
                x_dir /= 2;
                y_dir /= 2;
            }
            
        }
        if(shooting)
        {
            shooting = false;
            GameObject instance = Instantiate(bulletObject, playerRb.position, new Quaternion(0,0,0,0)) as GameObject;
            instance.GetComponent<BulletBehaviour>().speed = speed;
            instance.GetComponent<BulletBehaviour>().direction = new Vector2(x_dir, y_dir);
            instance.GetComponent<BulletBehaviour>().range = range;
            instance.GetComponent<BulletBehaviour>().isPlayerShooting = true;
            canShoot = false;
            x_dir = y_dir = 0;
            StartCoroutine(ShootDelay());
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }
}
