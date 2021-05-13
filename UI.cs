using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    
    bool paused;
    public GameObject[] uI;
    public Transform[] spawnPoints;
    private Transform chckpnt;
    private bool isHard;
    private GameObject mainChar;
    private bool pausable;

    void Start()
    {
        mainChar = GameObject.Find ("Main Char");
        paused = false;
        isHard = false;
        HideUI();
        Time.timeScale = 0;
        uI[6].SetActive(true);
        uI[7].SetActive(true);
        uI[8].SetActive(true);
        uI[9].SetActive(true);
        pausable = false;
    }

    public void PauseGame(){
        if(!paused){
            Time.timeScale = 0;
            paused = true;
            uI[1].SetActive(true);
            uI[2].SetActive(true);
        }
        else{
            Time.timeScale = 1;
            paused = false;
            uI[1].SetActive(false);
            uI[2].SetActive(false);
        }
    }

    public void LevelOne(){
        pausable = true;
        PlayingUI();
        mainChar.SetActive(true);
        Time.timeScale = 1;
        mainChar.GetComponent<PlayerMovement> ().MoveTo(spawnPoints[0]);
        SetCheckpoint(spawnPoints[0]);
        if(paused) PauseGame();
        GetComponent<SaveData> ().SaveIntoJson("1");
    }

    public void LevelTwo(){
        pausable = true;
        PlayingUI();
        mainChar.SetActive(true);
        Time.timeScale = 1;
        mainChar.GetComponent<PlayerMovement> ().MoveTo(spawnPoints[1]);
        SetCheckpoint(spawnPoints[1]);
        if(paused) PauseGame();
        GetComponent<SaveData> ().SaveIntoJson("2");
    }

    public void LevelThree(){
        pausable = true;
        PlayingUI();
        mainChar.SetActive(true);
        Time.timeScale = 1;
        mainChar.GetComponent<PlayerMovement> ().MoveTo(spawnPoints[2]);
        SetCheckpoint(spawnPoints[2]);
        if(paused) PauseGame();
        GetComponent<SaveData> ().SaveIntoJson("3");
    }

    public bool IsPaused(){
        return paused;
    }
    public Transform Checkpoint(){
        return chckpnt;
    }
    public void SetCheckpoint(Transform point){
        chckpnt = point;
    }

    public void MainMenu(){
        pausable = false;
        HideUI();
        Time.timeScale = 0;
        uI[6].SetActive(true);
        uI[7].SetActive(true);
        uI[8].SetActive(true);
        uI[9].SetActive(true);
        mainChar.GetComponent<PlayerMovement> ().MoveTo(spawnPoints[3]);
        mainChar.SetActive(false);
    }

    public void Difficulties(){
        HideUI();
        uI[10].SetActive(true);
        uI[11].SetActive(true);
    }

    public void HardDifficulty(){
        isHard = true;
        MainMenu();
    }

    public void EasyDifficulty(){
        isHard = false;
        MainMenu();
    }

    public void Levels(){
        HideUI();
        uI[3].SetActive(true);
        uI[4].SetActive(true);
        uI[5].SetActive(true);
    }

    public void HideUI(){
        for(int i = 0; i < uI.Length; i++){
            uI[i].SetActive(false);
        }
        mainChar.GetComponent<HealthSystem> ().HideHearts();
    }

    public void PlayingUI(){
        HideUI();
        mainChar.GetComponent<HealthSystem> ().HeartUpdate(16);
        uI[0].SetActive(true);
    }

    public void Continue(){
        string level = GetComponent<SaveData>() .ReturnLevelData();
        char[] datalist = level.ToString().ToCharArray();
        string asdf = "123";
        char one = asdf.ToString().ToCharArray()[0];
        char two = asdf.ToString().ToCharArray()[1];
        char three = asdf.ToString().ToCharArray()[2];
        if(level[0] == one) LevelOne();
        else if(level[0] == two) LevelTwo();
        else if(level[0] == three) LevelThree();
        else LevelOne();

    }

    public bool Difficulty(){
        return isHard;
    }
}
