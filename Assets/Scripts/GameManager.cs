using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    bool _isPause;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject("GameManager");
                var gameManager = obj.AddComponent<GameManager>();
                gameManager.AwakeSet();
                instance = gameManager;
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }
    private void AwakeSet()
    {
        InputManager.Instance.OnPauseInput += Pause;
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        _isPause = false;
        Cursor.visible = false;
    }
    public void Pause()
    {
        if (_isPause) Cursor.visible = true;
        else Cursor.visible = false;
    }
}
