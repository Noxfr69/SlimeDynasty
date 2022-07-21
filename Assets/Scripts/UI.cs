using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public void OnClickStart(){
       
       OverAllData.KillC = 0; 
       OverAllData.RunFinished = false;
       Time.timeScale = 1f;
       OverAllData.timer = 0;  
       Loader.Load(Loader.Scene.Level_1);
  
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void OnClickMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
        OverAllData.RunFinished = true;
        Time.timeScale = 1f;
    }

    public void OnClickDefendTheDynasty()
    {
        Loader.Load(Loader.Scene.TD_Level_1);
        OverAllData.RunFinished = true;
        Time.timeScale = 1f;
    }


}
