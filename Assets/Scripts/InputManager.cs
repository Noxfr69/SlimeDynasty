using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    InputController inputController;
    public GameObject PlayerSlime;
    PlayerSlime playerf;
    public GameObject SlimeAnimator;
    SlimeAnimator slimeAnimator;
    public Vector3 worldPosition;
    public Vector3 savedWPosV3;
    public Vector3 mDir;
    public Vector3 savedmDir;
    public bool isPressed = false;
    public bool isCasting1 = false;
    public bool isCasting2 = false;
    public bool isCasting3 = false;
    public bool isCasting4 = false;
    public bool isDashing = false;


    private void Awake() 
    
    {
        inputController = new InputController();
        playerf = PlayerSlime.GetComponent<PlayerSlime>();
        slimeAnimator = SlimeAnimator.GetComponent<SlimeAnimator>();
        
               
    }
    private void OnEnable() { inputController.Enable(); }
    private void OnDisable() { inputController.Disable(); }

    private void Start() {
        savedWPosV3 = playerf.transform.position;
    }
    void Update()
    {
        ////// mouse position transform into world point turn into a direction vector ////////////////
        Vector2 mousePosition = inputController.Normal.mousePosition.ReadValue<Vector2>();
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        mDir = savedWPosV3 - playerf.transform.position;
        savedmDir = worldPosition - playerf.transform.position;
        slimeAnimator.SetDirection(mDir); 


        ////// check if we are clicking or pressing the mouse ///////////////////////////////////////
  
        if(inputController.Normal.mousePress.ReadValue<float>() > 0.001f){
            savedWPosV3 = worldPosition;
            isPressed = true;
        }
        else{
            isPressed = false;
        }
            
        ////// SpellCast 1 ////////////////////////////////////////////////////////////////////////
        if(inputController.Normal.spellCast1.ReadValue<float>() > 0.1f){
             //savedWPosV3 = playerf.transform.position;
             isCasting1 = true;
        }
        else{
             isCasting1 = false;
        }

        ////// SpellCast 2 ////////////////////////////////////////////////////////////////////////
        if(inputController.Normal.spellCast2.ReadValue<float>() > 0.1f){
             //savedWPosV3 = playerf.transform.position;
             isCasting2 = true;
        }
        else{
             isCasting2 = false;
        }

        ////// SpellCast 3 ////////////////////////////////////////////////////////////////////////
        if(inputController.Normal.spellCast3.ReadValue<float>() > 0.1f){
             //savedWPosV3 = playerf.transform.position;
             isCasting3 = true;
        }
        else{
             isCasting3 = false;
        }


        ////// SpellCast 4 ////////////////////////////////////////////////////////////////////////
        if(inputController.Normal.spellCast4.ReadValue<float>() > 0.1f){
             //savedWPosV3 = playerf.transform.position;
             isCasting4 = true;
        }
        else{
             isCasting4 = false;
        }
        ///// Dash ///////////////////////////////////////////////////////////////////////////
         if(inputController.Normal.Dash.ReadValue<float>() > 0.1f){
              //WasPressedThisFrame()
              //savedWPosV3 = playerf.transform.position;
              isDashing = true;
         }
         else isDashing = false;

        //////////Shift///////////////////////////////////////////////////////////////////////// 
        if(inputController.Normal.CTRL.ReadValue<float>() > 0.1f){
             savedWPosV3 = playerf.transform.position;
        }

    }

}
