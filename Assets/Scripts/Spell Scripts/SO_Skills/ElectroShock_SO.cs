using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Player/ElectroShock_SO")]
public class ElectroShock_SO : Spells
{
    public override void Activate(GameObject parent, GameObject prefab ,Vector3 shootdir)
    {
        prefab = Instantiate(prefab, parent.transform.position, Quaternion.identity);
        prefab.GetComponent<ElectroShock>().Dmg(Damage);
        
    }
}
