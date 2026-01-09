using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    Rigidbody player;
    [SerializeField] float bounceSpeed = 14f;

    void Start(){
        player = GetComponent<Rigidbody>();
    }


    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Bounce")){
            other.gameObject.transform.GetComponent<Renderer>().material.color = new Color32(235,171,52,100);
            Invoke("Jump", 0.2f);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Bounce")){
            other.gameObject.transform.GetComponent<Renderer>().material.color = new Color32(225,229,124,100);
        }
    }

    void Jump(){
        player.velocity = new Vector3(player.velocity.x, bounceSpeed, player.velocity.z);
    }
}
