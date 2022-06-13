using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    int _currentHp;
    public int HP { get => _currentHp;  }
    [SerializeField]
    PlayerMoveController _moveController;
    [SerializeField]
    WeaponBase _weapon;
    /// <summary>
    /// 攻撃速度
    /// </summary>
    [SerializeField]
    float _attackRate;
    bool _isAttack;
    public event Action<int> OnChangeHp;
    public void StartControl()
    {
        InputManager.Instance.OnMoveInput += _moveController.Move;
        InputManager.Instance.OnFireInput += Attack;
        _currentHp = GameData.c_startPlayerHp;
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
        OnChangeHp?.Invoke(_currentHp);
        if (_currentHp <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        InputManager.Instance.OnMoveInput -= _moveController.Move;
        InputManager.Instance.OnFireInput -= Attack;
        EventManager.GameEnd();
    }
}
