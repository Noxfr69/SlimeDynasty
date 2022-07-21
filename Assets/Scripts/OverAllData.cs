using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverAllData : MonoBehaviour
{
    public static int KillC = 0;
    public static float timer;
    public static bool RunFinished;
    public static int Chosen_Difficulty = 0;
    public enum Difficulty{Easy, Normal, Hard}


  
    public static void KillCount(){
        KillC ++;
    }
    
    private void Update() {
        if(!RunFinished) {
            timer += Time.deltaTime; 
        }
    }

}
