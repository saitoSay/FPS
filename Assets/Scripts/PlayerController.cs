using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MoveController moveController;
    private void Start()
    {
        InputManager.Instance.OnMoveInput += moveController.Move;
    }
}
