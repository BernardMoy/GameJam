using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{   
    bool completedLvl1 = false;

    // Update is called once per frame
    void Update()
    {
        if (completedLvl1){
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Moving");
            foreach (GameObject platform in platforms){
                platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z + 4*Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("TEnter")){
            transform.position = new Vector3(44.1f,4.29f,57.5f);
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }


        //leave (level completed)
        if (collision.gameObject.CompareTag("Moving") && GetComponent<CoinsPickup>().complete == true){
            completedLvl1 = true;
            GameObject platformBottom = GameObject.Find("Target");
            transform.SetParent(platformBottom.transform);

            Invoke("NextLevel", 5f);
        }
    }

    void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }


}
