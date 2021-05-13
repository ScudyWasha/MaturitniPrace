using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
    public bool moving;
    public Transform moveTo;
    bool startMoving;
    public float moveSpeed;
    public void Action(){
        if(moving){
            startMoving = true;
        }
    }

    void Update(){
        if(startMoving){
            Move();
        }
    }

    void Move(){
        this.transform.position = Vector3.MoveTowards (this.transform.position, moveTo.position, Time.deltaTime * moveSpeed);
    }
}
