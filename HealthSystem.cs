using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject[] emptyHearts;
    private int life;
    private bool dead;
    private bool hitAble = true;
    private int maxHearts;
    public GameObject helpScript;
    public int deathCounter = 0;

    private void Start(){
        life = 16;
        maxHearts = 16;
        UpdateUI();
    }

    public void TakeDamage(int d){
        if (GameObject.Find ("UI"). GetComponent<UI> ().Difficulty()) d++;
        bool inmenu = GameObject.Find ("UI").GetComponent<UI> ().IsPaused();
        if(hitAble && !inmenu){
            if (life-d > 0)
            {
                for(int i = life-1; i > life-d-1; i--){
                    hearts[i].gameObject.SetActive(false);
                }
                life -= d;
            }
            else if(life == 0){
                Dead();
            }
            else{
                for(int i = life; i>=0;i--){
                    hearts[i].gameObject.SetActive(false);
                }
                Dead();
            }
        hitAble = false;
        StartCoroutine(DamageDelay());
        }
    }

    public void Heal(int d){
        if (life+d>maxHearts)
        {
            d=maxHearts-life;
        }
                for(int i = 0; i < life + d; i++){
                    hearts[i].gameObject.SetActive(true);
                }
            life += d;
            if (life < 1){
                dead = true;
            }
    }

    public void Dead(){
        GameObject.Find ("Main Char").GetComponent<PlayerMovement> ().MoveTo(GameObject.Find ("UI").GetComponent<UI> ().Checkpoint());
        life = maxHearts;
        Heal(life);
        deathCounter++;
    }
    
    IEnumerator DamageDelay()
   {
     yield return new WaitForSeconds(0.3f);
     hitAble = true;
   }

   public void HeartUpdate (int newHP){
       life = newHP;
       maxHearts = newHP;
       UpdateUI();
   }

   public void UpdateUI(){
       for(int i = 0; i < 16; i++){
           hearts[i].SetActive(true);
       }
       for(int i= 15; i != life-1; i--){
           hearts[i].SetActive(false);
       }
       for(int i = 0; i < 7; i++){
           emptyHearts[i].SetActive(true);
       }
       int help = life/2;
       for(int i = 7; i != help-1; i--){
           emptyHearts[i].SetActive(false);
       }
   }

   public int Deaths(){
       return deathCounter;
   }

   public void HideHearts(){
       for(int i = 0; i < hearts.Length; i++){
           hearts[i].SetActive(false);
       }
       for(int y = 0; y < emptyHearts.Length; y++){
           emptyHearts[y].SetActive(false);
       }
   }
}