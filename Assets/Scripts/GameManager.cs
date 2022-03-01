using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Material backgroundMaterial;
    public int selectedBackgroundIndex;
    public string playerName;
    public int highScore;
    public string highestPlayerName;

    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highestPlayerName;
    }

    public void SaveHighScore(){
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highestPlayerName = highestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestPlayerName = data.highestPlayerName;
            highScore = data.highScore;
        }
        
    }
}
