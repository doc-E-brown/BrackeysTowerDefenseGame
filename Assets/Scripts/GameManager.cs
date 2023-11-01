using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool _gameEnded = false;

    // Update is called once per frame
    void Update()
    {

        if (_gameEnded)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        
    }

    void EndGame()
    {
        _gameEnded = true;
       Debug.Log("Game over"); 
    }
}
