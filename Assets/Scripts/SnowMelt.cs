using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMelt : MonoBehaviour
{   
    int heatLevel = 0;
    Renderer playerRenderer;
    Rigidbody rb;

    [SerializeField] float turnRedDuration = 4f;
    [SerializeField] AudioSource dieSound;
    bool killed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heatLevel == 0){
            playerRenderer.material.color = new Color32(255,255,255,100);
        }
        else if (heatLevel <= 5){
            playerRenderer.material.color = new Color32(255,210,173,100);
        }
        else if (heatLevel < 10){
            playerRenderer.material.color = new Color32(255,190,173,100);
        }
        else if (heatLevel == 10){
            playerRenderer.material.color = new Color32(255,94,69,100);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Heat")){
            if (heatLevel <= 5){
                heatLevel += 5;
            }
            else if (heatLevel <= 10){  //max heat level = 10
                heatLevel = 10;
            }
        }

        //touches snow blocks
        if (collision.gameObject.CompareTag("Snow")){
            if (heatLevel != 0){
                Destroy(collision.gameObject);
                heatLevel --;
            }
        }

        //hit snow ball
        if (collision.gameObject.CompareTag("BossSnowball")){
            if (heatLevel >= 1){
                heatLevel -=1;
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Boss") && heatLevel > 0 && !killed){
            //Player wins
            killed = true;
            Debug.Log("Player wins!");
            dieSound.Play();
            Invoke("Freeze", 0.1f);

            GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");

            foreach (GameObject b in boss){
                StartCoroutine(TurnSnowmanRed(b.GetComponent<Renderer>()));
            }
        }
    }

    private IEnumerator TurnSnowmanRed(Renderer rend){

        float elapsedTime = 0;

        while (elapsedTime < turnRedDuration)
        {
            rend.material.color = Color.Lerp(new Color32(255,255,255,100), new Color32(255,111,79,100), elapsedTime / turnRedDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //After snowman dies

        rend.enabled = false;  //make snowman disappear

        GameObject s = GameObject.Find("Snowman");
        s.GetComponent<Snowman>().alive = false;
    }

    private void Freeze(){
        //reset heat level
        heatLevel = 0;
        playerRenderer.material.color = new Color32(255,255,255,100);
        //freeze player
        rb.constraints = RigidbodyConstraints.FreezePosition;
        //stop shooting and moving
    }
}
