using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody player;

  

    void Start()
    {
        Debug.Log("Game starts");
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //GetAxis --> 1 if moving to right, -1 if moving to left, 0 if not moving
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = GetComponent<Rigidbody>().velocity.y;
        float zMovement = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump") && IsGrounded()){
            yMovement = jumpHeight;
        }

        Vector3 movement = new Vector3(xMovement*speed, yMovement, zMovement*speed);
        player.velocity = movement;
        */
    }


    //Power-ups
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enlarge")){
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Danger");

            foreach (GameObject obj in objects){
                obj.transform.localScale = new Vector3(obj.transform.localScale.x * 2, obj.transform.localScale.y, obj.transform.localScale.z*2);
                
            }
        }
    }
}
