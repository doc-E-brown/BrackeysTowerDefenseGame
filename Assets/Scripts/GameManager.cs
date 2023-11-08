using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static bool _gameEnded = false;
    public GameObject gameOverUi;
    public GameObject completeLevelUi;

    private void Start()
    {
        _gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (_gameEnded)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        
    }

    void EndGame()
    {
        _gameEnded = true;
        gameOverUi.SetActive(true);
       Debug.Log("Game over"); 
    }

    public static bool IsGameOver()
    {
        return _gameEnded;
    }

    public void WinLevel()
    {
        _gameEnded = true;
        completeLevelUi.SetActive(true);
    }
    
}
