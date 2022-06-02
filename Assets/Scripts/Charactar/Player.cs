﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField]
    int _hp;
    int _currentHp;
    public int HP { get => _hp;  }



    public void Damage(int attackPoint)
    {
        _currentHp -= attackPoint;
    }
    private void Start()
    {
        _currentHp = HP;
    }
}
