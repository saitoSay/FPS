using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField]
    int _hp;
    [SerializeField]
    float _moveSpeed;
    [SerializeField]
    int _attackPoint;
    public virtual void Attack() { }
    public virtual void Damage() { }
    public virtual void Dead() { }
}
