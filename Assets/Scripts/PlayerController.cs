using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MoveController _moveController;
    private void Start()
    {
        InputManager.Instance.OnMoveInput += _moveController.Move;
        InputManager.Instance.OnRotateInput += _moveController.Rotate;
    }
}
