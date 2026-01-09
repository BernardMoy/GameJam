using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowers : MonoBehaviour
{
    Rigidbody player;
    [SerializeField] float blowSpeed = 3f;

    void Start(){
        player = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.transform.parent.CompareTag("BlowUp")){
            ChangeColor(other, new Color32(254,255,232,100));
            player.velocity = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z + blowSpeed);
        }
        if (other.gameObject.transform.parent.CompareTag("BlowDown")){
            ChangeColor(other, new Color32(254,255,232,100));
            player.velocity = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z - blowSpeed);            
        }
        if (other.gameObject.transform.parent.CompareTag("BlowLeft")){
            ChangeColor(other, new Color32(254,255,232,100));
            player.velocity = new Vector3(player.velocity.x - blowSpeed, player.velocity.y, player.velocity.z);            
        }
        if (other.gameObject.transform.parent.CompareTag("BlowRight")){
            ChangeColor(other, new Color32(254,255,232,100));
            player.velocity = new Vector3(player.velocity.x + blowSpeed, player.velocity.y, player.velocity.z);            
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.transform.parent.CompareTag("BlowUp") || other.gameObject.transform.parent.CompareTag("BlowDown") || other.gameObject.transform.parent.CompareTag("BlowLeft") || other.gameObject.transform.parent.CompareTag("BlowRight")){
            ChangeColor(other, new Color32(225,229,124,100));
        }
    }

    void ChangeColor(Collider other, Color32 color){
        foreach (Renderer child in other.gameObject.transform.parent.GetComponentsInChildren<Renderer>()){
            child.material.color = color;
        }
    }
}
