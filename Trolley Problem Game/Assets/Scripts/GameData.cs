using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int totalKills;
    public int totalSaved;
}

public class SaveSystem : MonoBehaviour
{
    private string path;

    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "KillsDataSaved.json");
    }

    public void SaveGame(int newKills, int newSaved)
    {
        GameData data = new GameData();

        data.totalKills = data.totalKills + newKills;
        data.totalSaved = data.totalSaved + newSaved;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);
    }

    public int getTotalKills()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            GameData data = JsonUtility.FromJson<GameData>(json);

            return data.totalKills;
        } 
        else
        {
            return 0;
        }
    }

    public int getTotalSaved()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            GameData data = JsonUtility.FromJson<GameData>(json);

            return data.totalSaved;
        }
        else
        {
            return 0;
        }
    }
}