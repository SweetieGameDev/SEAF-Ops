using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMeta : MonoBehaviour
{
    public void MainScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void TrainingScene(string Training)
    {
        SceneManager.LoadScene(Training);
    }

    public void DefenceScene(string Defence)
    {
        SceneManager.LoadScene(Defence);
    }

    public void CreditMe()
    {
        Application.OpenURL("https://linktr.ee/DoughNutGames");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
