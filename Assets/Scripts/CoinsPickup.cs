using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsPickup : MonoBehaviour
{

    int coinsNumber = 0;
    public GameObject locks;
    Renderer lockRenderer;

    float duration = 1.5f;

    public bool complete = false;

    [SerializeField] TMPro.TextMeshProUGUI coinsT;
    [SerializeField] AudioSource collectSound;

    void Start(){
        locks = GameObject.Find("Lock");
        if (locks != null){
            lockRenderer = locks.GetComponent<Renderer>();
        }
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
            coinsNumber++;
            collectSound.Play();
            coinsT.text = "Coins: " + coinsNumber + "/4";
        }
    }

    void Update(){
        //collected all coins
        if (coinsNumber >= 4){
            coinsNumber = -1;  //coinsNO = -1 means all are collected
            StartCoroutine(TurnLockToWhite());
            Invoke("DestroyLock", duration + 0.1f);
            complete = true;
        }
    }


    private IEnumerator TurnLockToWhite(){

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            lockRenderer.material.color = Color.Lerp(new Color32(225,229,124,100), new Color32(255,255,255,100), elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lockRenderer.material.color = new Color32(255,255,255,100); 
        StopCoroutine(TurnLockToWhite());
    }

    private void DestroyLock(){
        Destroy(locks);
    }
}