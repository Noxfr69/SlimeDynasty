using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item_Spells item;
    public int index;
    public List<Spells> spell = new List<Spells>(); 



    public void LookatCurrentSpells(int Current){
                
        if(Current == 0){
            int current = SavedData.currentSpell1ID;
            if(current != 0){
                gameObject.SetActive(true);
                gameObject.GetComponent<Image>().sprite = spell[current].Icon;
            }else gameObject.SetActive(false);
        }


        if(Current == 1){
            int current = SavedData.currentSpell2ID;
            if(current != 0){
                gameObject.SetActive(true);
                gameObject.GetComponent<Image>().sprite = spell[current].Icon;
            }else gameObject.SetActive(false);
        }


        if(Current == 2){
            int current = SavedData.currentSpell3ID;
            if(current != 0){
                gameObject.SetActive(true);
                gameObject.GetComponent<Image>().sprite = spell[current].Icon;
            }else gameObject.SetActive(false);
        }


        if(Current == 3){
            int current = SavedData.currentSpell4ID;
            if(current != 0){
                gameObject.SetActive(true);
                gameObject.GetComponent<Image>().sprite = spell[current].Icon;
            }else gameObject.SetActive(false);
        }

        if(Current == 4){
            int current = SavedData.currentDashID;
            if(current != 0){
                gameObject.SetActive(true);
                gameObject.GetComponent<Image>().sprite = spell[current].Icon;
            }else gameObject.SetActive(false);
        }

        return;
    }
    
}
