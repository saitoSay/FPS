using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed = 5;
    [SerializeField]
    Rigidbody _rb;
    [SerializeField]
    EnemyBase _enemy;
    private void Update()
    {
        if (!GameManager.Instance.InGame) return;
        if (_enemy.EnemyState == EnemyStates.Walk)
        {
            Move();
        }
        Rotate();
    }
    public void Move()
    {
        Vector3 velo = transform.forward * _moveSpeed;
        velo.y = _rb.velocity.y;
        _rb.velocity = velo;
    }
    public void Rotate()
    {
        // 対象物と自分自身の座標からベクトルを算出
        Vector3 vector3 = GameManager.Instance._player.transform.position - this.transform.position;
        vector3.y = 0f;

        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;
    }
}
