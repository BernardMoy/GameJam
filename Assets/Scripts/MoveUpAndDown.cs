using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
     
    [SerializeField] float speed = 1f;
    GameObject currentDestination;

    GameObject top;
    GameObject bottom;


    void Start(){
        top = new GameObject();
        top.name = "top";
        top.transform.parent = transform;
        top.transform.position = new Vector3(0, transform.localScale.y / 4, 0);

        bottom = new GameObject();
        bottom.name = "bottom";
        bottom.transform.parent = transform;
        bottom.transform.position = new Vector3(0, -transform.localScale.y / 4, 0);

        currentDestination = top;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Vector3.Distance(transform.position, currentDestination.transform.position) < 0.1f){
            if (currentDestination == top){
                currentDestination = bottom;
            }
            else{
                currentDestination = top;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, currentDestination.transform.position, speed * Time.deltaTime);
    }   
}
