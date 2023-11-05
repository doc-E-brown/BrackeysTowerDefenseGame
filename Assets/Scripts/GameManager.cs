using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static bool _gameEnded = false;

    public GameObject gameOverUi;

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

    public static bool isGameOver()
    {
        return _gameEnded;
    }
    
}
