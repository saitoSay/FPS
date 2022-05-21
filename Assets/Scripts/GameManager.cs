using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _isPause;
    public static GameManager Instance { get; private set; }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        InputManager.Instance.OnPauseInput += Pause;
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
