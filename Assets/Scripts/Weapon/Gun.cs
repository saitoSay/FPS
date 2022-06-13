using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : WeaponBase
{
    [SerializeField] 
    LineRenderer _line = null;
    /// <summary>
    /// 攻撃が当たるレイヤー
    /// </summary>
    [SerializeField] 
    LayerMask _layerMask = 0;
    /// <summary>
    /// 射程距離
    /// </summary>
    [SerializeField]
    float _attackRange = 15f;
    [SerializeField]
    ParticleSystem _shotEffect;
    GameObject hitObject;

    public override void Fire()
    {
        if (GameManager.Instance.InPause) return;
        if (_crosshairUi == null)
        {
            _crosshairUi = GameObject.Find("Crosshair").GetComponent<Image>();
        }
        // カメラから照準に向かってRayを飛ばし、当たっているオブジェクトを調べる
        Ray ray = Camera.main.ScreenPointToRay(_crosshairUi.rectTransform.position);
        RaycastHit hit;
        //Vector3 _hitPosition = _line.transform.position + _line.transform.forward * _attackRange;

        if (Physics.Raycast(ray, out hit, _attackRange, _layerMask))
        {
            //_hitPosition = hit.point;
            hitObject = hit.collider.gameObject;
        }
        if(hitObject != null)
        {
            if (hitObject.tag == "Enemy")
            {
                EnemyBase enemy = hitObject.GetComponent<EnemyBase>();
                enemy.Damage(_weaponData.GetAttackPoint());
            }
        }
        if (_shotEffect)
        {
            _shotEffect.Play();
        }
    }
}
