using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingAnimation : MonoBehaviour
{
    public Animator animator;
    public void Generate(){
        animator.SetTrigger("GrenadeDeployed");
    }
}
