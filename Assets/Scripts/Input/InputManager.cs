using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

/// <summary>
/// 入力を管理するクラス
/// </summary>
public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public event Action<Vector2> OnMoveInput;
    public event Action<Vector2> OnRotateInput;
    public event Action OnPauseInput;
    public event Action OnFireInput;
    ActionController _actionController;
    bool _isMove;
    bool _isRotate;
    public static InputManager Instance 
    {
        get 
        {
            if (instance == null)
            {
                var obj = new GameObject("InputManager");
                var input = obj.AddComponent<InputManager>();
                input.AwakeSet();
                instance = input;
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }
    private void AwakeSet()
    {
        _actionController = new ActionController();
        _actionController.Enable();
        _actionController.ActionMap.Move.performed += context => { StartMove(context); };
        _actionController.ActionMap.Move.canceled += context => { StopMove(); };
        _actionController.ActionMap.Fire.performed += context => { StartFire(); };
        _actionController.ActionMap.Pause.performed += context => { ChangePause(); };
    }

    void ChangePause()
    {
        OnPauseInput?.Invoke();
    }

    void StartMove(InputAction.CallbackContext context)
    {
        if(!_isMove) StartCoroutine(UpdateMove(context));
    }
    void StopMove()
    {
        _isMove = false;
    }
    void StartRotate(InputAction.CallbackContext context)
    {
        if(!_isRotate) StartCoroutine(UpdateRotate(context));
    }
    void StartFire()
    {
        OnFireInput?.Invoke();
    }
    void StopRotate()
    {
        _isRotate = false;
    }
    IEnumerator UpdateMove(InputAction.CallbackContext context)
    {
        _isMove = true;
        while (_isMove)
        {
            OnMoveInput?.Invoke(context.ReadValue<Vector2>());
            yield return null;
        }
    }
    IEnumerator UpdateRotate(InputAction.CallbackContext context)
    {
        _isRotate = true;
        while (_isRotate)
        {
            OnRotateInput?.Invoke(context.ReadValue<Vector2>());
            yield return null;
        }
    }
}
