using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject InputManager;
    PlayerSlime playerf;
    InputManager inputManager;
    public static Vector3 direction {get; private set;}
    


    void Start()
    {
        playerf = GetComponentInParent<PlayerSlime>();
        inputManager = InputManager.GetComponent<InputManager>();
    }

    

    void Update()
    {
        
        Vector3 offset = new Vector3(0,0.2f,0); // recenter because of sprite disposition 
        direction = inputManager.savedmDir.normalized + playerf.transform.position;
        transform.position = Vector3.LerpUnclamped(playerf.transform.position, direction, 0.2f);
        

    }
}
