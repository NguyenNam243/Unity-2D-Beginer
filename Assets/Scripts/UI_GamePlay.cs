using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GamePlay : MonoBehaviour
{
    public Toggle pauseBtn = null;
    public Button backMainMenuBtn = null;
    public Sprite[] pauseSprites = null;


    private void Start()
    {
        pauseBtn.onValueChanged.AddListener(OnPauseGame);
        backMainMenuBtn.onClick.AddListener(BackToMainMenu);
    }

    private void OnPauseGame(bool isOn)
    {
        Time.timeScale = isOn ? 0 : 1;
        pauseBtn.GetComponent<Image>().sprite = isOn ? pauseSprites[0] : pauseSprites[1];
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene((int)ScenceName.MainMenu);
    }
}
