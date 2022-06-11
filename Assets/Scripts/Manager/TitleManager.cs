using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    Button _startButton = default;

    [SerializeField]
    Text _startText = default;


    public void ChangeMainScene()
    {
        SceneChange.LoadGame("MainScene");
    }
}
