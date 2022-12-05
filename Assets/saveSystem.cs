using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class saveSystem : MonoBehaviour
{
    playerScript playerScr;
    healthScript healthScr;

    string savePath;
    saveData data;

    private void Awake()
    {
        playerScr = FindObjectOfType<playerScript>();
        healthScr = FindObjectOfType<healthScript>();

        savePath = Application.persistentDataPath + "/save.dat";
        if (!File.Exists(savePath))
        {
            saveData newData = new saveData();
            newData.playerPosition = Vector3.zero;
            newData.playerHealth = 100;
            SaveGame(newData);
        }
        data = LoadGame();
    }

    void SaveGame(saveData dataToSave)
    {
        string JsonData = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(savePath, JsonData);
    }

    saveData LoadGame()
    {
        string loadedData = File.ReadAllText(savePath);
        saveData dataToReturn = JsonUtility.FromJson<saveData>(loadedData);
        return dataToReturn;
    }

    public void SaveGameButton()
    {
        Vector3 playerPos = playerScr.GetPosition();
        int health = healthScr.GetHealth();

        data.playerPosition = playerPos;
        data.playerHealth = health;

        SaveGame(data);
    }

    public void LoadGameButton()
    {
        Vector3 playerPos = data.playerPosition;
        int health = data.playerHealth;

        playerScr.SetPosition(playerPos);
        healthScr.SetHealth(health);
    }
}

public class saveData
{
    public Vector3 playerPosition;
    public int playerHealth;
}
