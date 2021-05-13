using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float degreesPerSec = 720f;
    public Rigidbody2D rb;
    public float speed = 27f;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find ("Main Char").GetComponent<MovementTwo> ().IsFacingRight()){
            rb.velocity = transform.right * Mathf.Abs(speed);
            degreesPerSec = degreesPerSec * (-1);
            }
		else{
			rb.velocity = transform.right * speed * (-1);
		}
    }

    void Update()
    {
        float rotAmount = degreesPerSec * Time.deltaTime; 
        float curRot = transform.localRotation.eulerAngles.z; 
        transform.localRotation = Quaternion.Euler(new Vector3(0,0,curRot+rotAmount)); 
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }
}
