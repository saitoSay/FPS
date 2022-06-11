using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour,IDamagable
{
    [SerializeField]
    int _hp;
    public int HP { get => _hp; }
    [SerializeField]
    int _attackPoint;
    [SerializeField]
    float _attackRange;
    [SerializeField]
    float _attackRate;
    [SerializeField]
    GameObject _attackCollider;

    public EnemyStates EnemyState { get; private set; }
    public int CurrentHp { get; private set; }
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        if (GameManager.Instance.InGame == false) return;
        SearchPlayer();
    }

    private void SearchPlayer()
    {
        float distance = Vector3.Distance(this.transform.position, GameManager.Instance._player.transform.position);
        if (distance < _attackRange && EnemyState == EnemyStates.Walk)
        {
            EnemyState = EnemyStates.Attack;
            StartCoroutine(Attack());
        }
    }

    private void Init()
    {
        CurrentHp = _hp;
    }
    public virtual IEnumerator Attack()
    {
        _attackCollider.SetActive(true);
        yield return null;

        _attackCollider.SetActive(false);
        yield return new WaitForSeconds(_attackRate);

        EnemyState = EnemyStates.Walk;
        yield break;
    }
    public virtual void Damage(int attackPoint) 
    {
        CurrentHp -= attackPoint;
        if (CurrentHp <= 0)
        {
            Dead();
        }
    }
    public virtual void Dead()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance._player.Damage(_attackPoint);
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
