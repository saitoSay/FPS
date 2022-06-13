using System;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private const int c_defaultTimeScale = 1;
    private const int c_stopTimeScale = 0;

    public bool InGame { get; private set; }
    public bool InPause { get; private set; }
    /// <summary>
    /// 勝利フラグ
    /// </summary>
    private bool _winFrag;
    public Player _player;
    public event Action<int> OnEnemyCount;

    public event Action<int> OnPlayerUpdate;
    /// <summary>
    /// 倒す敵の残数
    /// </summary>
    int _currentEnemyCount;
    public int CurrentTargetNum
    {
        get { return _currentEnemyCount; }
        set
        {
            _currentEnemyCount = value;
            OnEnemyCount?.Invoke(_currentEnemyCount);
            //敵の数が0になったらゲームエンド
            if (_currentEnemyCount <= 0)
            {
                _winFrag = true;
                EventManager.GameEnd();
            }
        }
    }
    private CinemachineVirtualCamera _camera;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject("GameManager");
                var mangager = obj.AddComponent<GameManager>();
                EventManager.OnGameStart += () => mangager.GameStart();
                EventManager.OnGameEnd += () => mangager.GameEnd();
                instance = mangager;
                EventManager.GameStart();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }
    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    public void GameStart()
    {
        InputManager.Instance.OnPauseInput += ChangePause;

        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        _player = obj.GetComponent<Player>();
        _player.OnChangeHp += PlayerUpdate;
        _player.StartControl();

        var camera = GameObject.FindGameObjectWithTag("SubCamera");
        Instance._camera = camera.GetComponent<CinemachineVirtualCamera>();
        _camera.enabled = true;

        InGame = true;
        _winFrag = false;

        PauseOut();

        Cursor.visible = false;
        CurrentTargetNum = GameData.c_targetNum;

        FadeController.StartFadeIn();
    }
    /// <summary>
    /// ゲーム終了処理
    /// </summary>
    public void GameEnd()
    {
        InputManager.Instance.OnPauseInput -= ChangePause;
        _player.OnChangeHp -= PlayerUpdate;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        InGame = false;
        _camera.enabled = false;

        if (_winFrag) SceneChange.LoadScene("ResultScene");
        else SceneChange.LoadScene("GameoverScene");
    }
    /// <summary>
    /// ポーズ状況の変更
    /// </summary>
    public void ChangePause()
    {
        if (InGame == false) return;

        if (InPause)
        {
            PauseOut();
        }
        else
        {
            PauseIn();
        }
    }

    private void PauseOut()
    {
        Time.timeScale = c_defaultTimeScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InPause = false;
    }

    private void PauseIn()
    {
        Time.timeScale = c_stopTimeScale;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        InPause = true;
    }
    private void PlayerUpdate(int hp)
    {
        OnPlayerUpdate?.Invoke(hp);
    }
}
