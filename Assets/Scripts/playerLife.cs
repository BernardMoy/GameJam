using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour{

    bool dead = false;
    bool triggered = false;
    int lastArea = 1;

    [SerializeField] AudioSource deathSound;
    Vector3 spawnpoint = new Vector3(0, 5, 0);

    private void Update(){
        if (transform.position.y < -30f && !triggered){
            triggered = true;
            Die();
            deathSound.Play();
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("A1")){
            spawnpoint = new Vector3(0,5,0);
            lastArea = 1;
        }
        if (collision.gameObject.CompareTag("A2")){
            spawnpoint = new Vector3(-5.3f,5,13.9f);
            lastArea = 2;
        }
        if (collision.gameObject.CompareTag("A3")){
            spawnpoint = new Vector3(-3.3f,7,45.2f);
            lastArea = 3;
        }
        if (collision.gameObject.CompareTag("A4")){
            spawnpoint = new Vector3(29,5f,31.7f);
            lastArea = 4;
        }
        if (collision.gameObject.CompareTag("A6")){
            spawnpoint = new Vector3(43.9f,7,60.8f);
            lastArea = 6;
        }
        if (collision.gameObject.CompareTag("A7")){
            spawnpoint = new Vector3(13.4f,5,-5.85f);
            lastArea = 7;
        }
    }

    //Prevent player object being disabled which lead to this code being disabled 
    void Die(){
        if (!dead){

            Debug.Log("Player dies.");

            //Stop rendering the player
            GetComponent<MeshRenderer>().enabled = false;
            //Make it not affected by physics
            GetComponent<Rigidbody>().isKinematic = true;

            dead = true;

            //Call restart with delay
            Invoke(nameof(Restart), 0.8f);
        }
    }
       
    

    void Restart(){
        //Reload current scene & set dead to false
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GoToSpawn(){
        transform.position = spawnpoint;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        GameObject area = GameObject.Find("Area 1");

        switch(lastArea){
            case 1:
                area = GameObject.Find("Area 1");
                break;
            case 2:
                area = GameObject.Find("Area 2");
                break;
            case 3:
                area = GameObject.Find("Area 3");
                break;
            case 4:
                area = GameObject.Find("Area 4");
                break;
            case 6:
                area = GameObject.Find("Area 6");
                break;
            case 7:
                area = GameObject.Find("Area 7");
                break;
        }

        area.transform.rotation = Quaternion.identity;
    }
}
