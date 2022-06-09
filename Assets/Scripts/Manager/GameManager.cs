using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool InGame { get; private set; }
    public bool InPause { get; private set; }
    public Player _player;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject("GameManager");
                var mangager = obj.AddComponent<GameManager>();
                EventManager.OnGameStart += () => mangager.GameStart();
                EventManager.OnGameEnd += () => mangager.GameEnd();
                EventManager.GameStart();
                instance = mangager;
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }
    public void GameStart()
    {
        InputManager.Instance.OnPauseInput += ChangePause;
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        _player = obj.GetComponent<Player>();
        InGame = true;
        PauseOut();
        Cursor.visible = false;
    }
    public void GameEnd()
    {
        InGame = false;
    }
    public void ChangePause()
    {
        if (InGame == false) return;

        if (InPause)
        {
            PauseOut();
        }
        else
        {
            PauseIn();
        }
    }

    private void PauseOut()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InPause = false;
    }

    private void PauseIn()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        InPause = true;
    }
}
