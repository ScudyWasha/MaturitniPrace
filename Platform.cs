using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    public GameObject[] objectsToDisable;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Box"){
            for(int i = 0; i < objectsToDisable.Length; i++){
            objectsToDisable[i].SetActive(false);
        }
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Box"){
            for(int i = 0; i < objectsToDisable.Length; i++){
            objectsToDisable[i].SetActive(true);
        }
        }
    }
}
