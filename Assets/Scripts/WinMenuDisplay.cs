using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinMenuDisplay : MonoBehaviour
{
    public GameObject kills;
    public GameObject Time;
    public GameObject Difficulty;
    public GameObject Rewards;
    public GameObject TotalCoins;

    void Awake()
    {
        kills.GetComponentInChildren<TMP_Text>().text = OverAllData.KillC.ToString();
        // timer
        Debug.Log("Final timer" + OverAllData.timer);
        string minutes = ((int) OverAllData.timer / 60).ToString();
        string seconds = (OverAllData.timer % 60).ToString("f2");
        Time.GetComponentInChildren<TMP_Text>().text = minutes + ":" + seconds;
        OverAllData.RunFinished = true;
        Difficulty.GetComponentInChildren<TMP_Text>().text = ((OverAllData.Difficulty)OverAllData.Chosen_Difficulty).ToString();


        //rewards maths
        int rewards = 50 + ((OverAllData.KillC * OverAllData.Chosen_Difficulty) - (int)OverAllData.timer);
        if (rewards <= 50) rewards = 50;
        Rewards.GetComponentInChildren<TMP_Text>().text = (rewards).ToString();
        SavedData.RewardCoins += rewards;
        TotalCoins.GetComponentInChildren<TMP_Text>().text = (SavedData.RewardCoins).ToString();
        SavedData.refresh();

    }


    void Update()
    {
        
    }
}
