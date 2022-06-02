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
    public EnemyStates EnemyState { get; private set; }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyState = EnemyStates.Attack;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyState = EnemyStates.Walk;
        }
    }
}
public enum EnemyStates
{
    Walk,
    Wait,
    Attack,
    Freeze
};
