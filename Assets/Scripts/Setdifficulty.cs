using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setdifficulty : MonoBehaviour
{
    public GameObject Setdif;
    UI ui;
    private bool isActive = false;
   
    public void Setdiff(){
        if(!isActive){
            Setdif.SetActive(true);
            isActive = true;
        }else{
            Setdif.SetActive(false);
            isActive = false;
        }
    }

    public void Easy(){
        OverAllData.Chosen_Difficulty = 0;
        ui = GetComponent<UI>();
        ui.OnClickStart();
    }

    public void Medium(){
        OverAllData.Chosen_Difficulty = 1;
        ui = GetComponent<UI>();
        ui.OnClickStart();
    }

    public void Hard(){
        OverAllData.Chosen_Difficulty = 2;
        ui = GetComponent<UI>();
        ui.OnClickStart();
    }

}
