public class SceneChange
{
    private static bool roadNow = false;

    /// <summary>
    /// Mainシーンに移行する
    /// </summary>
    public static void LoadMain()
    {
        if (roadNow)
        {
            return;
        }
        roadNow = true;
        FadeController.StartFadeOutIn(Main, EventManager.GameStart);
    }
    /// <summary>
    /// シーンをロードする
    /// </summary>
    public static void LoadScene(string name)
    {
        if (roadNow)
        {
            return;
        }
        roadNow = true;
        FadeController.StartFadeOutIn(() => Change(name));
    }

    private static void Main()
    {
        roadNow = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    private static void Change(string name)
    {
        roadNow = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}