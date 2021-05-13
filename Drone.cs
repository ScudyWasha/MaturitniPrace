using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Transform endPosition;
    public GameObject projectile;
    public Transform playerDetection;
    public float fireRate;
    public float moveSpeed;
    public float detectRange;
    float nextFire;
    int currentGoal;
    int playerLayerMask;
    Vector3 currentPoint;
    GameObject grenadeAnimation;
    List<Vector3> points = new List<Vector3>();



    void Start()
    {
        nextFire = Time.time;
        points.Add(transform.position);
        points.Add(endPosition.position);
        currentPoint = points[0];
        playerLayerMask = LayerMask.GetMask("Player");
        grenadeAnimation = gameObject.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        Move();

        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, Vector2.down, detectRange, playerLayerMask);
        if(playerInfo){
            if(Time.time > nextFire){
                GameObject grenade = Instantiate(projectile, playerDetection.position, Quaternion.identity) as GameObject;
                nextFire = Time.time + fireRate;
                grenadeAnimation.GetComponent<GeneratingAnimation>().Generate();
            }
            
        }
    }

    void Move(){
        this.transform.position = Vector3.MoveTowards (this.transform.position, currentPoint, Time.deltaTime * moveSpeed);
        if (this.transform.position == currentPoint) {
            currentGoal++;
            if (currentGoal == points.Count){
                currentGoal = 0;

            }
            currentPoint = points[currentGoal];
        }
    }

    void OnDrawGizmosSelected(){

        Gizmos.DrawWireSphere(gameObject.transform.position, detectRange);
    } 
}
