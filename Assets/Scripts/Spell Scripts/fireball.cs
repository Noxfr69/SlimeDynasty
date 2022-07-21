using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{

    public GameObject hitEffect;
    private Vector3 shootDir;
    private float dmg = 10;
    private float radius = 0.5f;


    public void Dmg(int Dmg, float Radius){
        dmg = Dmg;
        radius = Radius;
    }

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        // to make the fireball face the right direction
        //get the angle with the eulerAngle
        float n = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        if(n<0) n += 360;
        transform.eulerAngles = new Vector3(0,0,n-90);
    }

    private void Update() {
        float moveSpeed = 10f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;
        Destroy(gameObject, 5f);
        
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        Target target = collider.GetComponent<Target>();
        if (target != null)
        {  
            //if(hb != null) hb.TakDamage(dmg);
            AOE();
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(gameObject);
                   
        }
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
