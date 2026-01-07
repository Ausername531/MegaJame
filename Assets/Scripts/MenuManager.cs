using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
