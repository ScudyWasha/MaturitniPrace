using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{

    public void SaveIntoJson(string level){
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/SaveData/LevelData.txt", false);
        writer.WriteLine(level);
        writer.Close();
    }
    public string ReturnLevelData(){
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/SaveData/LevelData.txt"); 
        string text = reader.ReadToEnd();
        reader.Close();
        return text;
    }
}