using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public string Name;
    public int HighScore;
    public string HighscoreName;



    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadInfo();
    }

    public void SetName(string s){
        Name = s;
        Debug.Log(Name);
    }

    [System.Serializable]
    class SavedData{
        public string playerName;
        public int highScore;
        public string highscoreName;
    }

    public void SaveInfo(){
        SavedData data = new SavedData();
        data.playerName = Name;
        data.highScore = HighScore;
        data.highscoreName = HighscoreName;
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            HighScore = data.highScore;
            HighscoreName = data.highscoreName;
            Debug.Log(Name);
        }
    }

}
