using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField]
    int _hp;
    [SerializeField]
    int _attackPoint;
    [SerializeField]
    float _attackRange;
    [SerializeField]
    float _attackFreezeTime;
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
        float distance = Vector2.Distance(this.transform.position, GameManager.Instance._player.transform.position);
        //vector2がx,y,zどの成分を持ってきているのか確認
        Debug.Log(GameManager.Instance._player.transform.position);
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
        GameManager.Instance._player.Damage(_attackPoint);
        _attackCollider.SetActive(false);
        yield return new WaitForSeconds(_attackFreezeTime);

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
