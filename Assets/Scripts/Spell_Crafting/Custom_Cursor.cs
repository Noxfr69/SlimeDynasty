using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Cursor : MonoBehaviour
{
    InputController inputController;
    private void Awake() { inputController = new InputController(); transform.position =  inputController.Normal.mousePosition.ReadValue<Vector2>();}
    private void OnEnable() { inputController.Enable(); }
    private void OnDisable() { inputController.Disable(); }

    void Update()
    {
       transform.position =  inputController.Normal.mousePosition.ReadValue<Vector2>();
    }
}
