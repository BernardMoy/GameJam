using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class collector : MonoBehaviour
{

    int powerUpNumber = 0;

    [SerializeField] Text coinsText;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PowerUp")){
            //Destroy the coin / powerup object
            Destroy(other.gameObject);

            //Enlarge player
            //EnlargeSize(2);

            powerUpNumber ++;
            Debug.Log("Power up hit");

            coinsText.text = "Power ups collected: " + powerUpNumber;
        }
    }

    private void EnlargeSize(float times){
        Transform transform = gameObject.transform;
        transform.localScale = new Vector3(transform.localScale.x * times, transform.localScale.y * times, transform.localScale.z * times);
    }

}
