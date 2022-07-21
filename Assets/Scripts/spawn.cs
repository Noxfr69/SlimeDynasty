using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private bool firsttime = true;

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerSlime player = other.GetComponent<PlayerSlime>();
        if(firsttime && player !=null){
            firsttime = false;
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
