using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField]
    int _hp;
    int _currentHp;
    public int HP { get => _hp;  }
    [SerializeField]
    PlayerMoveController _moveController;
    [SerializeField]
    WeaponBase _weapon;
    [SerializeField]
    float _attackRate;
    bool _isAttack;

    private void Start()
    {
        InputManager.Instance.OnMoveInput += _moveController.Move;
        InputManager.Instance.OnFireInput += Attack;
        _currentHp = HP;
        _isAttack = true;
    }
    public void Attack()
    {
        if (GameManager.Instance.InGame == false) return;

        if (_isAttack)
        {
            _weapon.Fire(); 
            StartCoroutine(WaitAttackTime(_attackRate));
        }
    }
    public IEnumerator WaitAttackTime(float waitTime)
    {
        _isAttack = false;
        yield return new WaitForSeconds(waitTime);
        _isAttack = true;
        yield break;
    }
    public void Damage(int attackPoint)
    {
        _currentHp -= attackPoint;
        Debug.Log(_currentHp);
        if (_currentHp <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        EventManager.GameEnd();
    }
}
