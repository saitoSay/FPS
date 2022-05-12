using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] 
    GameObject _muzzle = default;
    [SerializeField]
    GameObject _bulletPrefab = default;
    public virtual void Fire()
    {
        
    }
}
