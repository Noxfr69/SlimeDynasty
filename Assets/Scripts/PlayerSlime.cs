using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlime : MonoBehaviour
{
    public GameObject InputManager;
    PlayerSpellCast playerSpellCast;
    public GameObject UI;
    InputManager inputManager;
    public float MS=3f;
    public bool isPlayerMoving;
    private float DashCD = 5f;
    private float currentDashCD = 0f;
    private bool candash = true;
    Rigidbody2D rb;
    public static Vector3 PlayPos { get; private set; }
    public static Vector3 WorldPos { get; private set; }




    void Start()
    {
        playerSpellCast = GetComponent<PlayerSpellCast>();
        inputManager = InputManager.GetComponent<InputManager>();
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        WorldPos = inputManager.worldPosition;
        PlayPos = transform.position;
        //// player movement /////
        if(transform.position != inputManager.savedWPosV3){
            transform.position = Vector3.MoveTowards(transform.position , inputManager.savedWPosV3 ,MS * Time.deltaTime);
            isPlayerMoving = true;
        }       
        else{
            isPlayerMoving = false;
        }
        //// Dash ///////
        if(!candash){
            currentDashCD += Time.deltaTime;
            if(currentDashCD >= DashCD)
            {
                candash = true;
               // numberOfDash = 0;
                currentDashCD = 0;
            }
        }
        
    }

    public void SaveDir(){
        inputManager.savedWPosV3 = transform.position;
    }

}
