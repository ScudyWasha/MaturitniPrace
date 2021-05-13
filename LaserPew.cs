using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPew : MonoBehaviour
{
    public float timeLeft = 5f;
    void OnTriggerEnter2D (Collider2D hitInfo){
        string playerLayer = hitInfo.gameObject.tag;
        if (playerLayer == "Player")
		{
			GameObject.Find ("Main Char").GetComponent<MovementTwo> ().Knockback();
            GameObject.Find ("Main Char").GetComponent<HealthSystem> ().TakeDamage(3);
            Destroy(gameObject);
		}     
        else if (playerLayer == "Foreground" || playerLayer == "Box"){
            Destroy(gameObject);
        }   
    }
      void Update() {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0) {
            Destroy(gameObject);
        }
    }
}
