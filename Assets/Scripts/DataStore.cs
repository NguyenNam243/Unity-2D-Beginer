using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DataStore : MonoBehaviour
{
    public PlayerScriptable playerData;

    float timePlaying = 0;




    private void Awake()
    {
        if (PlayerPrefs.HasKey(GameConstants.StartGameKey) && PlayerPrefs.HasKey(GameConstants.ExitGameKey))
        {
            DateTime timeStart = DateTime.Parse(PlayerPrefs.GetString(GameConstants.StartGameKey));
            DateTime timeExit = DateTime.Parse(PlayerPrefs.GetString(GameConstants.ExitGameKey));
            timePlaying = (float)(timeExit - timeStart).TotalMinutes;
            Debug.Log("Time Playing: " + timePlaying);
        }

        PlayerPrefs.SetString(GameConstants.StartGameKey, DateTime.Now.ToString());

        //WritePlayerDataToJson();

        //PlayerConfig playerData = GetPlayerDataFromJson();
        //PlayerController controller = GetComponent<PlayerController>();
        //controller.moveSpeed = playerData.moveSpeed;
        //controller.jumpForce= playerData.jumpForce;


        PlayerController controller = GetComponent<PlayerController>();
        controller.moveSpeed = playerData.moveSpeed;
        controller.jumpForce = playerData.jumpForce;
    }


    private PlayerConfig GetPlayerDataFromJson()
    {
        string json = File.ReadAllText("Assets/Config/PlayerData.json");
        //PlayerConfig data = JsonUtility.FromJson<PlayerConfig>(json);
        PlayerConfig data = JsonConvert.DeserializeObject<PlayerConfig>(json);
        return data;
    }


    private void WritePlayerDataToJson()
    {
        PlayerConfig playerData = new PlayerConfig("Wizard", 5, 750, 100, 10);
        string json = JsonUtility.ToJson(playerData);
        //string json = JsonConvert.SerializeObject(playerData);


        File.WriteAllText("Assets/Config/PlayerData.json", json);
        Debug.Log("Write player data complete");
    }


    private void OnDestroy()
    {
        PlayerPrefs.SetString(GameConstants.ExitGameKey, DateTime.Now.ToString());
    }
}

public class GameConstants
{
    public static readonly string StartGameKey = "StartGame";
    public static readonly string ExitGameKey = "ExitGame";
}
