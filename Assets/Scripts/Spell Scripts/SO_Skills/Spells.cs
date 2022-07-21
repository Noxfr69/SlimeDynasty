using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spells : ScriptableObject
{
    public new string name;
    public string Description;
    public int ID;
    public Sprite Icon;
    public int Damage;
    public float Cooldown;
    public float Radius;
    public int UnlockCost;
    public int Number_of_Charges = 1;
    public float Time_Between_2_charges = 0.2f;
    public bool CanHaveCharge = false;


    public virtual void Activate(GameObject parent, GameObject prefab , Vector3 shootdir){}

}
