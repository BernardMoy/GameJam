using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{   
    Rigidbody player;
    int iceCollisionNumber = 0;
    bool spedUp = false;
    
    [SerializeField] float speedMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {   
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(spedUp);

        //have collision and havent speed up
        if (iceCollisionNumber > 0 && !spedUp){
            player.velocity = new Vector3(player.velocity.x *speedMultiplier, player.velocity.y *speedMultiplier, player.velocity.z *speedMultiplier);
            spedUp = true;
        }
        //leave ice collision and sped up
        if (iceCollisionNumber == 0 && spedUp){
            player.velocity = new Vector3(player.velocity.x /speedMultiplier, player.velocity.y /speedMultiplier, player.velocity.z /speedMultiplier);
            spedUp = false;
        }
    }

    private void OnCollisionEnter(Collision collision){
        iceCollisionNumber ++;
    }

    private void OnCollisionExit(Collision collision){
        iceCollisionNumber --;
    }
}
