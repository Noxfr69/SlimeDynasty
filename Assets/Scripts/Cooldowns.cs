using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldowns : MonoBehaviour
{
    public Image Q; 
    private float Q_cd;
    private bool qIsInCd = false;

    public Image W;
    private float w_cd;
    private bool wIsInCd = false;


    public Image E; 
    private float e_cd;
    private bool eIsInCd = false;


    public Image R;
    private float r_cd;
    private bool rIsInCd = false;


    public Image Space;
    private float space_cd;
    private bool spaceIsInCd = false;
    


    public void CD_Q(float cooldown)
    {
        qIsInCd = true;
        Q.fillAmount = 1;
        Q_cd = cooldown;
    }

    public void CD_W(float cooldown)
    {
        wIsInCd = true;
        W.fillAmount = 1;
        w_cd = cooldown;
    }

    public void CD_E(float cooldown)
    {
        
        eIsInCd = true;
        E.fillAmount = 1;
        e_cd = cooldown;
    }

    public void CD_R(float cooldown)
    {
        
        rIsInCd = true;
        R.fillAmount = 1;
        r_cd = cooldown;
    }

    public void CD_Space(float cooldown)
    {
        
        spaceIsInCd = true;
        Space.fillAmount = 1;
        space_cd = cooldown;
    }



    private void OnAwake() {
        qIsInCd = false; Q.fillAmount = 0;
        wIsInCd = false; W.fillAmount = 0;
        eIsInCd = false; E.fillAmount = 0;
        rIsInCd = false; R.fillAmount = 0;
        spaceIsInCd = false; Space.fillAmount = 0;
    }
    private void OnDestroy() {
        qIsInCd = false; Q.fillAmount = 0;
        wIsInCd = false; W.fillAmount = 0;
        eIsInCd = false; E.fillAmount = 0;
        rIsInCd = false; R.fillAmount = 0;
        spaceIsInCd = false; Space.fillAmount = 0;
    }





    private void Update() {
    if(qIsInCd) Q.fillAmount -= (1 / Q_cd) * Time.deltaTime;
    if(wIsInCd) W.fillAmount -= (1 / w_cd) * Time.deltaTime;
    if(eIsInCd) E.fillAmount -= (1 / e_cd) * Time.deltaTime;
    if(rIsInCd) R.fillAmount -= (1 / r_cd) * Time.deltaTime;
    if(spaceIsInCd) Space.fillAmount -= (1 / space_cd) * Time.deltaTime;


    }

}
