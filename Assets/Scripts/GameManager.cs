using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _isPause;
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
                mangager.Init();
                instance = mangager;
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }
    public void Init()
    {
        InputManager.Instance.OnPauseInput += Pause;
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        _player = obj.GetComponent<Player>();
        _isPause = false;
        Cursor.visible = false;
    }
    public void Pause()
    {
        if (_isPause)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isPause = false;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _isPause = true;
        }
    }
}
