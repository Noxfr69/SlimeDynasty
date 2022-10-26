using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUp_Menu : MonoBehaviour
{
    public GameObject skillUP_Canvas;
    public GameObject MainMenu_Canvas;
    public GameObject ModeSelectCanvas;
    public GameObject TotalCoins;
    public GameObject slotQ;
    public GameObject slotW;
    public GameObject slotE;
    public GameObject slotR;
    public GameObject slotSpace;

    private void Awake() {
        skillUP_Canvas.SetActive(false);
        MainMenu_Canvas.SetActive(true);
    }
    public void OnSkillupClick()
    {
        skillUP_Canvas.SetActive(true);
        MainMenu_Canvas.SetActive(false);
        Slots slotq = slotQ.GetComponent<Slots>();
        Slots slotw = slotW.GetComponent<Slots>();
        Slots slote = slotE.GetComponent<Slots>();
        Slots slotr = slotR.GetComponent<Slots>();
        Slots slotspace = slotSpace.GetComponent<Slots>();
        slotq.LookatCurrentSpells(0);
        slotw.LookatCurrentSpells(1);
        slote.LookatCurrentSpells(2);
        slotr.LookatCurrentSpells(3);
        slotspace.LookatCurrentSpells(4);


    }

    public void OnClickMenu()
    {
        skillUP_Canvas.SetActive(false);
        ModeSelectCanvas.SetActive(false);
        MainMenu_Canvas.SetActive(true); 
    }

    public void OnClickReset(){
        SavedData.RewardCoins += SavedData.UsedCoins;
        SavedData.UsedCoins = 0;
        for (int i = 0; i < 10; i++){
            string isunlocked = "SpellUnlocked" + i.ToString();
            PlayerPrefs.SetInt(isunlocked , 0);
        } 
        slotQ.SetActive(false);
        slotQ.GetComponent<Image>().sprite = null;
        SavedData.currentSpell1ID = 0;

        slotW.SetActive(false);
        slotW.GetComponent<Image>().sprite = null;
        SavedData.currentSpell2ID = 0;

        slotE.SetActive(false);
        slotE.GetComponent<Image>().sprite = null;
        SavedData.currentSpell3ID = 0;

        slotR.SetActive(false);
        slotR.GetComponent<Image>().sprite = null;
        SavedData.currentSpell4ID = 0;

        slotSpace.SetActive(false);
        slotSpace.GetComponent<Image>().sprite = null;
        SavedData.currentDashID = 0;
        SavedData.refresh();
    }

    public void OnClickSave()
    {
        SavedData.refresh();
    }

    private void Update() {

        TotalCoins.GetComponentInChildren<TMP_Text>().text = ("Total coin : " + SavedData.RewardCoins).ToString();
    }
}
