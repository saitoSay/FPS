using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "ScriptableObjects/CreateEnemyParamAsset")]
public class ScriptableWeaponData : ScriptableObject
{
    [SerializeField]
    int _attackPoint;
    [SerializeField]
    int _fireInterval;
    [SerializeField]
    int _magazineCapacity;
    public int GetAttackPoint() => _attackPoint;
    public int GetFireInterval() => _fireInterval;
    public int GetMagazineCapacity() => _magazineCapacity;
}
