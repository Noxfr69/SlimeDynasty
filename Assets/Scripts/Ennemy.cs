using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ennemy : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float blink_duration = 0.1f;
    private float Blink_Timer = 0; 
    public GameObject PopUpDamage;

    void Start() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Die()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; 
        CapsuleCollider2D cc = GetComponent<CapsuleCollider2D>();
        cc.enabled = false;   
        Destroy(gameObject, 0.5f);
    }

    public void OnHiteffect()
    {
        Blink_Timer = blink_duration;
    }

    private void Update() 
    {
        if(Blink_Timer >= 0)
        {
            Blink_Timer -= Time.deltaTime;
            spriteRenderer.color = Color.red;
        }
    }

    public void PopUp(float amountDmg){

        if(amountDmg<40){
            var txt = Instantiate(PopUpDamage, transform.position, Quaternion.identity, transform);
            txt.GetComponent<TMP_Text>().text = amountDmg.ToString("f0");
            txt.GetComponent<TMP_Text>().faceColor = Color.green;
            txt.GetComponent<TMP_Text>().fontSize = Random.Range(2,4);
        }
        if(amountDmg >=40 && amountDmg<80 ){
            var txt = Instantiate(PopUpDamage, transform.position, Quaternion.identity, transform);
            txt.GetComponent<TMP_Text>().text = amountDmg.ToString("f0");
            txt.GetComponent<TMP_Text>().faceColor = Color.yellow;
            txt.GetComponent<TMP_Text>().fontSize = Random.Range(5,8);
        }
        if(amountDmg>=80){
            var txt = Instantiate(PopUpDamage, transform.position, Quaternion.identity, transform);
            txt.GetComponent<TMP_Text>().text = amountDmg.ToString("f0");
            txt.GetComponent<TMP_Text>().faceColor = Color.red;
            txt.GetComponent<TMP_Text>().fontSize = Random.Range(10,20);
        }

    }





}