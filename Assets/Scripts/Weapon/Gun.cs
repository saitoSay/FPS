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
    GameObject hitObject;
    public override void Fire()
    {
        if (GameManager.Instance.InPause) return;

        _ray = Camera.main.ScreenPointToRay(_crosshairUi.rectTransform.position);

        if (Physics.Raycast(_ray, out _hit, _shootRange, _layerMask))
        {
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
