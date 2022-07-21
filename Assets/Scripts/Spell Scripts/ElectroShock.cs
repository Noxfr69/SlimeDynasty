using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroShock : MonoBehaviour
{
    private int damage;
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    public void Dmg(int dmg){
        damage = dmg;
    }


    // Update is called once per frame
   void OnTriggerEnter2D(Collider2D collider){

        float finalDmg = Random.Range((damage + (damage * SavedData.DamageBonus))-5, (damage + (damage * SavedData.DamageBonus))+5);
        HB hb = collider.GetComponentInChildren<HB>();
        if(hb != null) hb.TakDamage(finalDmg);
     }
}
