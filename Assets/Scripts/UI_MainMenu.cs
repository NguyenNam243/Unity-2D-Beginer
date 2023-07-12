using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ScenceName
{
    MainMenu,
    GamePlay
}

public class UI_MainMenu : MonoBehaviour
{
    public Button playGameBtn = null;


    private void Start()
    {
        playGameBtn.onClick.AddListener(OnStartGame);
    }

    private void OnStartGame()
    {
        SceneManager.LoadScene((int)ScenceName.GamePlay);
    }
}
