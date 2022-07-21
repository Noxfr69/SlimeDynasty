using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
public GameObject ChooseLevelCanvas;
    private void Awake() 
    {
        ChooseLevelCanvas.SetActive(false);
    }



    public void OnclickChooseLevel()
    {
        ChooseLevelCanvas.SetActive(true);
    }
}
