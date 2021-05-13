using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hP = 4;
    
     void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Shuriken"){
            hP--;
        }
        if(hP <= 0){
             Destroy(gameObject);
        }
     }
    
}
