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
    public int CurrentHp { get; private set; }
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        CurrentHp = _hp;
    }
    public virtual void Attack() { }
    public virtual void Damage(int attackPoint) 
    {
        CurrentHp -= attackPoint;
        if (CurrentHp <= 0)
        {
            Dead();
        }
        Debug.Log(CurrentHp);
    }
    public virtual void Dead()
    {
        //ここで爆発など、死ぬときの演出を実行する
        Destroy(this.gameObject);
    }
}
