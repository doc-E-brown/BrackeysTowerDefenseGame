using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public SceneFader SceneFader;
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // Update is called once per frame
    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
