using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;
    public Button[] levelButtons;

    void Start()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 0);
        for (int idx = 0; idx < levelButtons.Length; idx++)
        {
            levelButtons[idx].interactable = (idx <= levelReached);
        }
    }

    public void Select(string level)
    {
        fader.FadeTo(level);
    }
}
