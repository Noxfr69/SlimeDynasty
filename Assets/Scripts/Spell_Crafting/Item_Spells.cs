using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Spells : MonoBehaviour
{
    public Spells spell;
    public bool isUnlocked;
    public int Price;
    public int ID;

    void Awake()
    {
        awakesetbool();
        ID = spell.ID;
        Price = spell.UnlockCost;
        gameObject.GetComponent<Image>().sprite = spell.Icon;
        gameObject.transform.Find("description").GetComponent<TMP_Text>().text = spell.Description;
        gameObject.transform.Find("price").GetComponent<TMP_Text>().text = spell.UnlockCost.ToString();
    }

    public void refreshBool(){
        isUnlocked = true;
        string isunlocked = "SpellUnlocked" + spell.ID.ToString();
        Debug.Log(isunlocked);
        PlayerPrefs.SetInt(isunlocked , 1);
        gameObject.GetComponent<Image>().color = Color.white;
    }

    public void awakesetbool(){

        string isunlocked = "SpellUnlocked" + spell.ID.ToString();
        int unlocked = PlayerPrefs.GetInt(isunlocked,0);
        if(unlocked == 0){isUnlocked = false; Debug.Log("not unlocked");} 
        if(unlocked == 1){isUnlocked = true; Debug.Log("unlocked");}
    }


    private void Update() {
        if(!isUnlocked){
            gameObject.GetComponent<Image>().color = Color.grey;
        }else gameObject.GetComponent<Image>().color = Color.white;
    }
}
