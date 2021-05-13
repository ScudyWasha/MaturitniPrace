using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject leverAction;
    public string teleportTo;
    bool inRangeOfLever;
    public bool pressingOnce;
    public Animator animator;
    public bool final;
    bool done;
    void Start()
    {
        if(pressingOnce){
            done = false;
        }   
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && inRangeOfLever && !done){
            if(final)  Application.LoadLevel(Application.loadedLevel);
            leverAction.GetComponent<LeverAction>().Action();
            if(pressingOnce){
            if(teleportTo != null) StartCoroutine(TeleportDelay());
            done = true;
            animator.SetTrigger("Activated");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            inRangeOfLever = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            inRangeOfLever = false;
        }
    }
    IEnumerator TeleportDelay()
   {
     yield return new WaitForSeconds(0.5f);
     switch (teleportTo){
                case "lvl 1":
                    GameObject.Find ("UI").GetComponent<UI> ().LevelOne();
                    break;
                case "lvl 2":
                GameObject.Find ("UI").GetComponent<UI> ().LevelTwo();
                    break;
                case "lvl 3":
                GameObject.Find ("UI").GetComponent<UI> ().LevelThree();
                    break;
                case "mainmenu":
                GameObject.Find ("UI").GetComponent<UI> ().MainMenu();
                    break;

            }  
   }
}
