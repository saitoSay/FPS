using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _hpText;
    [SerializeField]
    Text _enemyCountText;
    private void OnEnable()
    {
        GameManager.Instance.OnEnemyCount += ChangeEnemyText;
        GameManager.Instance.OnPlayerUpdate += ChangeHpText;
        _enemyCountText.text = $"残り {GameData.c_targetNum} 体";
        _hpText.text = $"残り体力 {GameData.c_startPlayerHp}";
    }
    private void OnDisable()
    {
        GameManager.Instance.OnEnemyCount -= ChangeEnemyText;
        GameManager.Instance.OnPlayerUpdate -= ChangeHpText;
    }
    public void ChangeEnemyText(int num)
    {
        _enemyCountText.text = $"残り {num} 体";
    }
    public void ChangeHpText(int hp)
    {
        _hpText.text = $"残り体力 {hp}";
    }
}
