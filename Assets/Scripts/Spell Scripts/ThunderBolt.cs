using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBolt : MonoBehaviour
{
    private float dmg = 10;
    private float radius = 0.5f;
    private Vector3 shootDir;


    public void Dmg(int Dmg, float Radius){
        dmg = Dmg;
        radius = Radius;
        AOE();
        Destroy(gameObject,5f);
        transform.eulerAngles = new Vector3(90,0,0);
    }


    private void AOE()
    {
        Collider2D [] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D c in colliders)
        {
            float finalDmg = Random.Range((dmg + (dmg * SavedData.DamageBonus))-5, (dmg + (dmg * SavedData.DamageBonus))+5);
            HB hb = c.GetComponentInChildren<HB>();
            if(hb != null) hb.TakDamage(finalDmg);
        }
    }
}
