using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Player/Fireball")]
public class Fireball_SO : Spells
{

        public override void Activate(GameObject parent, GameObject prefab ,Vector3 shootdir)
    {

        Vector3 shoodir = shootdir;
        prefab = Instantiate(prefab, parent.transform.position, Quaternion.identity);
        prefab.GetComponent<fireball>().Setup(shoodir);
        prefab.GetComponent<fireball>().Dmg(Damage, Radius);
        prefab.transform.parent =parent.transform;
        
    }

}
