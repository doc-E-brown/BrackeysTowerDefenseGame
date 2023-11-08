using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI roundsText;
    public SceneFader sceneFader;
    public string mainMenu = "MainMenu";


    private void OnEnable()
    {
       roundsText.text = PlayerStats.RoundsSurvived().ToString(); 
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);

    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenu);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
