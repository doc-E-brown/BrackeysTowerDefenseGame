using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public static int Lives;

    public int startMoney = 400;
    public int startLives = 20;
    private static int _roundsSurvived = 0;
    void Start()
    {
        Money = startMoney;
        Lives = startLives;

    }

    public static void LoseLife()
    {
        Lives--;
    }

    public static void AddMoney(int value)
    {
        Money += value;
    }

    public static void SurvivedRound()
    {
        _roundsSurvived++;
    }

    public static int RoundsSurvived()
    {
        return _roundsSurvived;
    }
}
