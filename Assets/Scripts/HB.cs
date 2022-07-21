using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HB : MonoBehaviour
{

    public float MaxHealth;
    public float CurrentHealth;
    public GameObject Ennemy;
    Ennemy ennemy;
    private Vector3 scale = new Vector3(1,1,0);
    public GameObject HealthBar;
    private float amountDmg;


    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.transform.localScale = scale;
        ennemy = Ennemy.GetComponentInParent<Ennemy>();
        //GameObject HB = GameObject.Find("HB");
        //GameObject hb = HB.transform.GetChild(0).gameObject;
        //hb.transform.localScale = scale;

    }

    public void TakDamage(float amountDmg)
    {
        this.amountDmg = amountDmg;
        ennemy.OnHiteffect();
        ennemy.PopUp(amountDmg);
        CurrentHealth -= amountDmg;
        //GameObject HB = GameObject.Find("HB");
        //GameObject hb = HB.transform.GetChild(0).gameObject;
        float dmg100 = amountDmg*100/MaxHealth;
        scale.x -= dmg100/100;
        HealthBar.transform.localScale = scale;

        if (CurrentHealth <= 0.0f) {
            OverAllData.KillCount();
            ennemy.Die();
        }
    }



}
