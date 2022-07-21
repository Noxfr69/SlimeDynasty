using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour
{
   
    
    public static int RewardCoins;
    public static int UsedCoins;
#region Spells
    public static int currentSpell1ID;
    public static int currentSpell2ID;   
    public static int currentSpell3ID;   
    public static int currentSpell4ID;
    public static int currentDashID;
#endregion    
#region Stats
    public static int BonusCharges;
    public static int DamageBonus;
#endregion

    private void Awake() {
        DamageBonus = PlayerPrefs.GetInt("DamageBonus",0);
        currentSpell1ID = PlayerPrefs.GetInt("CurrentSpell1", 1);
        currentSpell2ID = PlayerPrefs.GetInt("CurrentSpell2", 0);
        currentSpell3ID = PlayerPrefs.GetInt("CurrentSpell3", 0);
        currentSpell4ID = PlayerPrefs.GetInt("CurrentSpell4", 0);
        currentDashID = PlayerPrefs.GetInt("CurrentDash", 0);
        BonusCharges = PlayerPrefs.GetInt("BonusCharges", 0);

        RewardCoins = PlayerPrefs.GetInt("RewardCoins", 0);
        
        UsedCoins = PlayerPrefs.GetInt("UsedCoins", 0);
        Debug.Log(SavedData.currentSpell1ID);
        Debug.Log(SavedData.currentSpell2ID);
        Debug.Log(SavedData.currentSpell3ID);
        Debug.Log(SavedData.currentSpell4ID);
        Debug.Log(SavedData.currentDashID);

    }

    public static void refresh(){
       PlayerPrefs.SetInt("DamageBonus",DamageBonus);
       PlayerPrefs.SetInt("BonusCharges", BonusCharges);
    


       PlayerPrefs.SetInt("CurrentSpell1", currentSpell1ID);
       PlayerPrefs.SetInt("CurrentSpell2", currentSpell2ID);
       PlayerPrefs.SetInt("CurrentSpell3", currentSpell3ID);
       PlayerPrefs.SetInt("CurrentSpell4", currentSpell4ID);
       PlayerPrefs.SetInt("CurrentDash", currentDashID);

       PlayerPrefs.SetInt("RewardCoins", RewardCoins);
       PlayerPrefs.SetInt("UsedCoins", UsedCoins);

    }
}
