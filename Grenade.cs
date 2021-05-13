using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    GameObject range;

    void Start(){
        range = transform.GetChild (0).gameObject;
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag == "Player"){
            GameObject.Find ("Main Char").GetComponent<HealthSystem> ().TakeDamage(4);
            Destroy(gameObject);
        }
        StartCoroutine(ExplosionDelay());
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    IEnumerator ExplosionDelay()
   {
     yield return new WaitForSeconds(0.5f);
     if(range.GetComponent<InRange> ().InGrenadeRange()){
            GameObject.Find ("Main Char").GetComponent<HealthSystem> ().TakeDamage(3);
        }
     Destroy(gameObject);
   }
}