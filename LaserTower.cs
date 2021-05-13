using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public Transform playerDetection;
    public Transform firePoint;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate;
    float nextFire;

    float detectRange;
    int playerLayerMask;

    void Start()
    {
        nextFire = Time.time;
    }

    void Update()
    {
        int playerLayerMask = LayerMask.GetMask("Player"); 
        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, Vector2.left, detectRange, playerLayerMask);
        //if(playerInfo.collider == true) 
        if(Time.time > nextFire) {
            GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * (projectileSpeed / 100));
            nextFire = Time.time + fireRate;
        }
    }
}