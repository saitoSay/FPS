using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject _muzzle = default;
    [SerializeField]
    protected ScriptableWeaponData _weaponData;
    [SerializeField]
    protected Image _crosshairUi = null;
    public virtual void Fire()
    {
        
    }
}
