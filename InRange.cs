using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRange : MonoBehaviour
{
    private bool inRange;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            inRange = false;
        }
    }
    public bool InGrenadeRange(){
        return inRange;
    }
}
