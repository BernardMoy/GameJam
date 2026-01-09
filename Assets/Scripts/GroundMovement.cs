using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundMovement : MonoBehaviour
{

    [SerializeField] float period = 7f;

    Quaternion currentRotation;
    int collisionNumber = 0;

    bool pressingW = false;
    bool doubleW = false;
    bool pressingA = false;
    bool doubleA = false;
    bool pressingS = false;
    bool doubleS = false;
    bool pressingD = false;
    bool doubleD = false;


    [SerializeField] int doubleClickCooldown = 4; //4s double click cooldown
    int cooldown = 0; // current cooldown
    float time = 0; // time for executing function every s

    GameObject playerObj;
    GameObject playerHitbox;
    Rigidbody rb;

    [SerializeField] float launcherStrength = 3.5f;
    float originalHeight = 0;

    [SerializeField] TMPro.TextMeshProUGUI cooldownT;
    [SerializeField] AudioSource launchSound;

    void Start(){
        currentRotation = GetComponent<Transform>().rotation;
        playerHitbox = GameObject.Find("PlayerHitbox");
        playerObj = GameObject.Find("Player");  //player gameObject
        rb = playerObj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   

        //Movement when colliding with player
        if (collisionNumber!=0){
            float horizontalMovement = Input.GetAxis("Horizontal"); //z
            float verticalMovement = Input.GetAxis("Vertical"); //x

            transform.Rotate(360*verticalMovement/period*Time.deltaTime, 0, -360*horizontalMovement/period*Time.deltaTime);


            //Double clicking launchers (4s cooldown)
            if (Input.GetKeyDown("w") && !pressingW){
                Invoke("PressingW", 0.01f);
                Invoke("DisablePressing", 0.25f);
            }
            if (Input.GetKeyDown("w") && pressingW && cooldown == 0){
                DisablePressing();
                originalHeight = playerObj.transform.position.y;
                doubleW = true;
                cooldown += doubleClickCooldown;
                launchSound.Play();
                Invoke("DisableDoubleW", 0.125f);
            }

            //Double clicking launcher actions (0.125s)
            if (doubleW){
                EnableDoubleW();
            }




            //Double clicking launchers (4s cooldown)
            if (Input.GetKeyDown("a") && !pressingA){
                Invoke("PressingA", 0.01f);
                Invoke("DisablePressing", 0.25f);
            }
            if (Input.GetKeyDown("a") && pressingA && cooldown == 0){
                DisablePressing();
                originalHeight = playerObj.transform.position.y;
                doubleA = true;
                cooldown += doubleClickCooldown;
                launchSound.Play();
                Invoke("DisableDoubleA", 0.125f);
            }

            //Double clicking launcher actions (0.125s)
            if (doubleA){
                EnableDoubleA();
            }

            //Double clicking launchers (4s cooldown)
            if (Input.GetKeyDown("s") && !pressingS){
                Invoke("PressingS", 0.01f);
                Invoke("DisablePressing", 0.25f);
            }
            if (Input.GetKeyDown("s") && pressingS && cooldown == 0){
                DisablePressing();
                originalHeight = playerObj.transform.position.y;
                doubleS = true;
                cooldown += doubleClickCooldown;
                launchSound.Play();
                Invoke("DisableDoubleS", 0.125f);
            }

            //Double clicking launcher actions (0.125s)
            if (doubleS){
                EnableDoubleS();
            }



            //Double clicking launchers (4s cooldown)
            if (Input.GetKeyDown("d") && !pressingD){
                Invoke("PressingD", 0.01f);
                Invoke("DisablePressing", 0.25f);
            }
            if (Input.GetKeyDown("d") && pressingD && cooldown == 0){
                DisablePressing();
                originalHeight = playerObj.transform.position.y;
                doubleD = true;
                cooldown += doubleClickCooldown;
                launchSound.Play();
                Invoke("DisableDoubleD", 0.125f);
            }

            //Double clicking launcher actions (0.125s)
            if (doubleD){
                EnableDoubleD();
            }
        }


        //Reset if space is pressed
        if (Input.GetKey("space")){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, currentRotation, 360/period*Time.deltaTime);
        }

        //Constantly reducing cooldown
        time += Time.deltaTime;
        if (time >= 1){
            if (cooldown > 0){
                cooldown--;
                Debug.Log("Cooldown: " + cooldown);
                cooldownT.text = "Cooldown: " + cooldown;

                if (cooldown == 0){
                    cooldownT.text = "";
                }
            }
            time --;
        }
    }


    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "PlayerHitbox"){
            collisionNumber++;

        }
    }
    void OnTriggerExit(Collider collision){
        if (collision.gameObject.tag == "PlayerHitbox"){
            collisionNumber--;
        }
    }
    
    private void Rotate(float x, float y, float z){
        transform.Rotate(x*Time.deltaTime, y*Time.deltaTime, z*Time.deltaTime);
    }

    //Methods for double click launchers

    private void DisablePressing(){
        pressingW = false;
        pressingA = false;
        pressingS = false;
        pressingD = false;
    }
    private void PressingW(){
        pressingW = true;
    }

    private void EnableDoubleW(){
        playerObj.transform.SetParent(transform);
        transform.Rotate(280*Time.deltaTime, 0,0);
    }

    private void DisableDoubleW(){
        doubleW = false;
        playerObj.transform.SetParent(null);
        
        float heightDifference = playerObj.transform.position.y - originalHeight;
        //player moved up
        if (heightDifference > 0){
            float newVelocity = heightDifference * launcherStrength; //v = 3.5 (delta h)
            rb.velocity = new Vector3(rb.velocity.x, newVelocity, newVelocity + 1.6f*rb.velocity.z);
        }
    }

    private void PressingA(){
        pressingA = true;
    }

    private void EnableDoubleA(){
        playerObj.transform.SetParent(transform);
        transform.Rotate(0, 0, 280*Time.deltaTime);
    }

    private void DisableDoubleA(){
        doubleA = false;
        playerObj.transform.SetParent(null);
        
        float heightDifference = playerObj.transform.position.y - originalHeight;
        //player moved up
        if (heightDifference > 0){
            float newVelocity = heightDifference * launcherStrength; //v = 3.5 (delta h)
            rb.velocity = new Vector3(-newVelocity + 1.6f*rb.velocity.x, newVelocity, rb.velocity.z);
        }
    }

    private void PressingS(){
        pressingS = true;
    }

    private void EnableDoubleS(){
        playerObj.transform.SetParent(transform);
        transform.Rotate(-280*Time.deltaTime, 0,0);
    }

    private void DisableDoubleS(){
        doubleS = false;
        playerObj.transform.SetParent(null);
        
        float heightDifference = playerObj.transform.position.y - originalHeight;
        //player moved up
        if (heightDifference > 0){
            float newVelocity = heightDifference * launcherStrength; //v = 3.5 (delta h)
            rb.velocity = new Vector3(rb.velocity.x, newVelocity, -newVelocity + 1.6f*rb.velocity.z);
        }
    }

    private void PressingD(){
        pressingD = true;
    }

    private void EnableDoubleD(){
        playerObj.transform.SetParent(transform);
        transform.Rotate(0, 0, -280*Time.deltaTime);
    }

    private void DisableDoubleD(){
        doubleD = false;
        playerObj.transform.SetParent(null);
        
        float heightDifference = playerObj.transform.position.y - originalHeight;
        //player moved up
        if (heightDifference > 0){
            float newVelocity = heightDifference * launcherStrength; //v = 3.5 (delta h)
            rb.velocity = new Vector3(newVelocity + 1.6f*rb.velocity.x, newVelocity, rb.velocity.z);
        }
    }

    private void DecreaseCooldown(){
        cooldown --;
    }
}
