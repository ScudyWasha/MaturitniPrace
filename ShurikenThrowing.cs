using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenThrowing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shuriken;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)|| Input.GetKeyDown(KeyCode.LeftControl)){
            if(!GameObject.Find ("UI").GetComponent<UI> ().IsPaused())
            Shoot();
        }
    }
    private void Shoot(){
        Instantiate(shuriken, firePoint.position, firePoint.rotation);
    }
}
