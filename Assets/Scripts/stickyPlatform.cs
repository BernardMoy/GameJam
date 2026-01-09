using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){

        //collision with player
        if (collision.gameObject.name == "Player"){
            //transform = transform of the object where the script is attached to
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision){

        //collision with player
        if (collision.gameObject.name == "Player"){
            //transform = transform of the object where the script is attached to
            collision.gameObject.transform.SetParent(null);
        }
    }
}
