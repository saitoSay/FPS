using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour,IDamagable
{
    [SerializeField]
    int _hp;
    public int HP { get => _hp; }
    /// <summary>
    /// 攻撃力
    /// </summary>
    [SerializeField]
    int _attackPoint;
    /// <summary>
    /// 攻撃をする距離
    /// </summary>
    [SerializeField]
    float _attackRange;
    /// <summary>
    /// 攻撃速度
    /// </summary>
    [SerializeField]
    float _attackRate;
    /// <summary>
    /// 攻撃判定
    /// </summary>
    [SerializeField]
    GameObject _attackCollider;
    [SerializeField]
    ParticleSystem _hitEffect;

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
        //1フレームだけ当たり判定を作成
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
        if (_hitEffect)
        {
            _hitEffect.Play();
        }
        if (CurrentHp <= 0)
        {
            Dead();
        }
    }
    public virtual void Dead()
    {
        //クリアまでの目標数を1減らす
        GameManager.Instance.CurrentTargetNum -= 1;
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
