using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    private Item_Spells currentItem;
    public Image custoCursor;
    public Slots[] craftingslots;
    private bool currentBool;
    private int alreadyThere=0; // check if the spell is already in the bar
#region InputController
    InputController inputController;
    private void Awake() { inputController = new InputController(); transform.position =  inputController.Normal.mousePosition.ReadValue<Vector2>();}
    private void OnEnable() { inputController.Enable(); }
    private void OnDisable() { inputController.Disable(); }
#endregion

    public void OnReset(Item_Spells item){
        item.awakesetbool();
    }


    public void OnmousDownItem(Item_Spells item){
        if(currentItem == null){
            currentItem = item;
            item.awakesetbool(); // we check the current status of the bool
            currentBool = item.isUnlocked;
            if(item.isUnlocked){
                custoCursor.gameObject.SetActive(true);
                custoCursor.sprite = currentItem.GetComponent<Image>().sprite;
            }else if(item.Price <= SavedData.RewardCoins){
                SavedData.RewardCoins -= item.Price;
                SavedData.UsedCoins += item.Price;
                SavedData.refresh(); // save the coin spending
                item.refreshBool(); // we set the unlock bool to true 
            }else{
                Debug.Log("can't buy too poor!");
                return;
            }
        }
    }

    private void Update() {

        if(inputController.Normal.mousePress.WasReleasedThisFrame()){
            if(currentItem != null && currentBool){
                custoCursor.gameObject.SetActive(false);
                Slots nearestSlot = null;
                float shortesDistance = float.MaxValue;
                Debug.Log("mouse released");

                foreach(Slots slots in craftingslots){
                    float dist = Vector2.Distance(custoCursor.transform.position, slots.transform.position);

                    if(dist < shortesDistance){
                        shortesDistance = dist;
                        nearestSlot = slots;
                    }
                }
                alreadyThere = 0;
                foreach (Slots slots in craftingslots)
                {
                    if(currentItem.GetComponent<Image>().sprite == slots.GetComponent<Image>().sprite){
                        alreadyThere++;
                        Debug.Log("You Already have this spell");
                    }

                }
                if(alreadyThere == 0){
                    nearestSlot.gameObject.SetActive(true);
                    nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                    nearestSlot.item = currentItem;
                    if(nearestSlot.index == 0){
                        SavedData.currentSpell1ID = currentItem.ID;
                    }
                    if(nearestSlot.index == 1){
                        SavedData.currentSpell2ID = currentItem.ID;
                    }
                    if(nearestSlot.index == 2){
                        SavedData.currentSpell3ID = currentItem.ID;
                    }
                    if(nearestSlot.index == 3){
                        SavedData.currentSpell4ID = currentItem.ID;
                }
                    if(nearestSlot.index == 4){
                        SavedData.currentDashID = currentItem.ID;
                }
                else{}
        }
                // if no spell similar in the other spells
                
            }else currentItem = null;
        currentItem = null;
        } 
    }



}
