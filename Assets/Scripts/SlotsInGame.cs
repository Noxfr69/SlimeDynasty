using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsInGame : MonoBehaviour
{
    public int index;
    public List<Spells> spell = new List<Spells>(); 
    private Color color = new Color(0,0,0,0);



    public void Awake(){
                
        if(index == 0){
            Debug.Log("index is 0");
            gameObject.GetComponent<Image>().sprite = spell[SavedData.currentSpell1ID].Icon;
            if(SavedData.currentSpell1ID == 00){
                gameObject.GetComponent<Image>().color = color;
            }
        }

        if(index == 1){
            gameObject.GetComponent<Image>().sprite = spell[SavedData.currentSpell2ID].Icon;
            if(SavedData.currentSpell2ID == 00){
                gameObject.GetComponent<Image>().color = color;
            }
        }

        if(index == 2){
            gameObject.GetComponent<Image>().sprite = spell[SavedData.currentSpell3ID].Icon;
            if(SavedData.currentSpell3ID == 00){
                gameObject.GetComponent<Image>().color = color;
            }
        }

        if(index == 3){
            gameObject.GetComponent<Image>().sprite = spell[SavedData.currentSpell4ID].Icon;
            if(SavedData.currentSpell4ID == 00){
                gameObject.GetComponent<Image>().color = color;
            }
        }

        if(index == 4){
            gameObject.GetComponent<Image>().sprite = spell[SavedData.currentDashID].Icon;
            if(SavedData.currentDashID == 00){
                gameObject.GetComponent<Image>().color = color;
            }
        }


    }
    
}
