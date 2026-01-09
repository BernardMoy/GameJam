using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snowman : MonoBehaviour
{   
    GameObject player;
    GameObject centerSnowball;
    Transform playerTransform;
    float distance;
    float distancex;
    float distancey;
    float distancez;

    [SerializeField] float shootSpeed = 50f;
    [SerializeField] float interval = 0.8f;
    [SerializeField] float triggerShootDistance = 20f;
    [SerializeField] float triggerMoveDistance = 12f;
    [SerializeField] float escapeSpeed = 5f;
    [SerializeField] float moveThreshold = 16f;

    float time;

    float movedx = 0;
    float movedz = 0;
    Renderer rend;
    public bool alive = true;

    [SerializeField] AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        centerSnowball = GameObject.Find("CenterSnowball");
        time = 0f;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update(){   
        
        time += Time.deltaTime;

        playerTransform = player.transform;

        distance = Vector3.Distance(playerTransform.position, transform.position);
        distancex = playerTransform.position.x - transform.position.x;
        distancey = playerTransform.position.y - transform.position.y;
        distancez = playerTransform.position.z - transform.position.z;

        transform.LookAt(playerTransform);

        if (time > interval){
            //check every second
            if (distance < triggerShootDistance && alive){
                Shoot(distance, distancex, distancey, distancez);
                shootSound.Play();
            }
            time = 0f;
        }

        if (distance < triggerMoveDistance && alive){
            float x = -Math.Sign(distancex)*escapeSpeed*Time.deltaTime;
            float z = -Math.Sign(distancez)*escapeSpeed*Time.deltaTime;

            if (distancex < 0 && movedx > moveThreshold || distancex > 0 && movedx < -moveThreshold){
                x = 0f;
            }
            if (distancez < 0 && movedz > moveThreshold || distancez > 0 && movedz < -moveThreshold){
                z = 0f;
            }

            movedx += x;
            movedz += z;

            transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        }


    }

    void Shoot(float distance, float distancex, float distancey, float distancez){

        GameObject projectile = Instantiate(centerSnowball, centerSnowball.transform.position, centerSnowball.transform.rotation);
        projectile.transform.SetParent(transform);
        projectile.transform.position = transform.position;
        projectile.GetComponent<Renderer>().enabled = true;

        projectile.GetComponent<Rigidbody>().velocity = new Vector3(shootSpeed*distancex / distance, shootSpeed*distancey / distance, shootSpeed*distancez / distance);
    }


}
