using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public event Action<Vector2> OnMoveInput;
    ActionController _actionController;
    bool _isMove;
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
    }
    void StartMove(InputAction.CallbackContext context)
    {
        if(!_isMove) StartCoroutine(UpdateMove(context));
    }
    void StopMove()
    {
        _isMove = false;
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
}
