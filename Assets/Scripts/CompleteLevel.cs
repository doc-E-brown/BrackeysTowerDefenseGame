using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string nextLevel = "Level2";
    public int levelToUnlock = 1;
    public string mainMenu = "MainMenu";
    
    public void Menu()
    {
        sceneFader.FadeTo(mainMenu);
        
    }

    public void Continue()
    {
        int currentLevel = PlayerPrefs.GetInt("levelReached", 0);
        if (levelToUnlock > currentLevel)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo(nextLevel);    
    }
}
