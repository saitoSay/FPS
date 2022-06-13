using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public bool InGame { get; private set; }
    public bool InPause { get; private set; }
    private bool _winFrag;
    public Player _player;
    int _currentTargetNum;
    public int CurrentTargetNum
    {
        get { return _currentTargetNum; }
        set
        {
            _currentTargetNum = value;
            if (_currentTargetNum <= 0)
            {
                _winFrag = true;
                EventManager.GameEnd();
            }
        }
    }
    private CinemachineVirtualCamera _camera;
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
                instance = mangager;
                EventManager.GameStart();
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
        var camera = GameObject.FindGameObjectWithTag("SubCamera");
        instance._camera = camera.GetComponent<CinemachineVirtualCamera>();
        _camera.enabled = true;
        InGame = true;
        _winFrag = false;
        PauseOut();
        Cursor.visible = false;
        CurrentTargetNum = Data._targetNum;
        FadeController.StartFadeIn();
    }
    public void GameEnd()
    {
        InputManager.Instance.OnPauseInput -= ChangePause;
        InGame = false;
        _camera.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if(_winFrag) SceneChange.LoadScene("ResultScene");
        else SceneChange.LoadScene("GameoverScene");
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
