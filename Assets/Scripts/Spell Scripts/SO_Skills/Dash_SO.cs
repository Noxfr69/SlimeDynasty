using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Player/Dash_SO")]
public class Dash_SO : Spells
{

    public override void Activate(GameObject parent, GameObject prefab ,Vector3 shootdir)
    {

        prefab = Instantiate(prefab, PlayerSlime.WorldPos, Quaternion.identity);
        prefab.transform.parent =parent.transform;
        //prefab.GetComponent<ThunderBolt>().Dmg(Damage, Radius);
    }

}
