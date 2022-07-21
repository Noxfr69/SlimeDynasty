using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Player/ThunderBolt_SO")]
public class ThunderBolt_SO : Spells
{

    public override void Activate(GameObject parent, GameObject prefab ,Vector3 shootdir)
    {

        prefab = Instantiate(prefab, PlayerSlime.WorldPos, Quaternion.identity);
        prefab.GetComponent<ThunderBolt>().Dmg(Damage, Radius);
              
    }

}
