using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : WeaponBase
{
    [SerializeField] 
    Image _crosshairUi = null;
    [SerializeField] 
    LineRenderer _line = null;
    [SerializeField] 
    LayerMask _layerMask = 0;
    [SerializeField] 
    float _shootRange = 15f;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(_crosshairUi.rectTransform.position);
        RaycastHit hit;
        Vector3 hitPosition = _line.transform.position + _line.transform.forward * _shootRange;  // hitPosition は Ray が当たった場所。Line の終点となる。何にも当たっていない時は Muzzle から射程距離だけ前方にする。
        GameObject hitObject = null;    // Ray が当たったオブジェクト

        // Ray が何かに当たったか・当たっていないかで処理を分ける        
        if (Physics.Raycast(ray, out hit, _shootRange, _layerMask))
        {
            hitPosition = hit.point;    // Ray が当たった場所
            hitObject = hit.collider.gameObject;    // Ray が洗ったオブジェクト
        }
    }
    public override void Fire()
    {

    }
}
