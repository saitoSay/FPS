using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public void ChangeScene(string name)
    {
        if (name == "MainScene") SceneChange.LoadMain();
        else SceneChange.LoadScene(name);
    }
}
