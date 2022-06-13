using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] 
    Transform[] _generatPoints;
    [SerializeField] 
    GameObject _enemyPrefab;
    [SerializeField] 
    float _popTime;
    [SerializeField] 
    int _maxRandNum = 0;
    float _randNum;
    float _currnetTime = 0;
    private void OnEnable()
    {
        EventManager.OnGameStart += () => SpawnStart();
        EventManager.OnGameEnd += () => SpawnEnd();
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= () => SpawnStart();
        EventManager.OnGameEnd -= () => SpawnEnd();
    }
    private void Update()
    {
        if (!GameManager.Instance.InGame) return;
        _currnetTime += Time.deltaTime;

        if (_currnetTime > _popTime + _randNum) Spawn();
    }
    public void Spawn()
    {
        _currnetTime = 0;
        _randNum = Random.Range(0, _maxRandNum);

        int randPoint = Random.Range(0, _generatPoints.Length);
        Instantiate(_enemyPrefab, _generatPoints[randPoint].transform.position, Quaternion.identity);
    }
    public void SpawnStart()
    {
        _currnetTime = 0;
        _randNum = Random.Range(0, _maxRandNum);

    }
    public void SpawnEnd()
    {

    }
}