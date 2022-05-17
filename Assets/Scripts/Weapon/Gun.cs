using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : WeaponBase
{
    [SerializeField] 
    LineRenderer _line = null;
    [SerializeField] 
    LayerMask _layerMask = 0;
    [SerializeField]
    float _shootRange = 15f;
    Ray _ray;
    RaycastHit _hit;
    Vector3 _hitPosition;
    GameObject hitObject;
    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(_crosshairUi.rectTransform.position);
        _hitPosition = _line.transform.position + _line.transform.forward * _shootRange;
        hitObject = null;
    }
    public override void Fire()
    {
        if (Physics.Raycast(_ray, out _hit, _shootRange, _layerMask))
        {
            _hitPosition = _hit.point;
            hitObject = _hit.collider.gameObject;
        }
        if(hitObject != null)
        {
            if (hitObject.tag == "Enemy")
            {
                EnemyBase enemy = hitObject.GetComponent<EnemyBase>();
                enemy.Damage(_weaponData.GetAttackPoint());
            }
        }
        Debug.Log(hitObject);
    }
}
