using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellCast : MonoBehaviour
{
    public GameObject InputManager;
    InputManager inputmanager;
    public Transform FirePoint;
    public GameObject fireballPrefab;
    public GameObject UI;
    FirePoint firepoint;
    private Transform playref;
    private TrailRenderer trailRenderer;

#region bools and cd data
    private bool castingmagic1 = false;
    //private float timeBetweenCasts1 = 0.25f;
    private float currentCastTimer1 = 0;
    private bool castingmagic2 = false;
    //private float timeBetweenCasts2 = 5f;
    private float currentCastTimer2 = 0;
    private bool castingmagic3 = false;
    //private float timeBetweenCasts3 = 0.5f;
    private float currentCastTimer3 = 0;
    private bool castingmagic4 = false;
    private float currentCastTimer4 = 0;
    private bool castingmagicSpace = false;
    private float currentCastTimerSpace = 0;
    private int charges_used_Space = 0;
    private float buffer_Space = 0;
    public List<Transform> tp;
#endregion    
    [Header("Player Spells")]
    public List<Spells> spell = new List<Spells>(); 
    public List<GameObject> spell_prefab = new List<GameObject>(); 

          



    // Start is called before the first frame update
    void Start()
    {
        inputmanager = InputManager.GetComponent<InputManager>();
        firepoint = FirePoint.GetComponent<FirePoint>();
        playref = GetComponent<Transform>();
        tp.Add(transform); 
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;
    }

#region Update Cooldowns and bool for spell cast
    // Update is called once per frame
    void Update()
    {
        ////// SpellCast1
        if(inputmanager.isCasting1 && !castingmagic1)
        {
            castingmagic1 = true;
            currentCastTimer1 = 0;
            Spell1();
            Cooldowns cd = UI.GetComponent<Cooldowns>();
            cd.CD_Q(spell[SavedData.currentSpell1ID].Cooldown);

        }else   
        {
            currentCastTimer1 += Time.deltaTime;
            if(currentCastTimer1 > spell[SavedData.currentSpell1ID].Cooldown) castingmagic1 = false;
        }


        ////// SpellCast2
        if(inputmanager.isCasting2 && !castingmagic2)
        {
            castingmagic2 = true;
            currentCastTimer2 = 0;
            Spell2();
            Cooldowns cd = UI.GetComponent<Cooldowns>();
            cd.CD_W(spell[SavedData.currentSpell2ID].Cooldown);

        }else   
        {
            currentCastTimer2 += Time.deltaTime;
            if(currentCastTimer2 > spell[SavedData.currentSpell2ID].Cooldown) castingmagic2 = false;
        }

        ////// SpellCast3
        if(inputmanager.isCasting3 && !castingmagic3)
        {
            castingmagic3 = true;
            currentCastTimer3 = 0;
            Spell3();
            Cooldowns cd = UI.GetComponent<Cooldowns>();
            cd.CD_E(spell[SavedData.currentSpell3ID].Cooldown);

        }else   
        {
            currentCastTimer3 += Time.deltaTime;
            if(currentCastTimer3 > spell[SavedData.currentSpell3ID].Cooldown) castingmagic3 = false;
        }

        ////// SpellCast4
        if(inputmanager.isCasting4 && !castingmagic4)
        {
            castingmagic4 = true;
            currentCastTimer4 = 0;
            spell4();
            Cooldowns cd = UI.GetComponent<Cooldowns>();
            cd.CD_R(spell[SavedData.currentSpell4ID].Cooldown);

        }else   
        {
            currentCastTimer4 += Time.deltaTime;
            if(currentCastTimer4 > spell[SavedData.currentSpell4ID].Cooldown) castingmagic4 = false;
        }
        ////// SpellCastSpace ///////////////////////////////////////////////////////////////////////////////////
        if(inputmanager.isDashing && !castingmagicSpace)
        {   
            
            if(!spell[SavedData.currentDashID].CanHaveCharge){
                
                    currentCastTimerSpace = 0; 
                    castingmagicSpace = true;
                    spellSpace();
                    Cooldowns cd = UI.GetComponent<Cooldowns>();
                    cd.CD_Space(spell[SavedData.currentDashID].Cooldown);
            }else{
                int charges = spell[SavedData.currentDashID].Number_of_Charges + SavedData.BonusCharges;
                if(charges == charges_used_Space){
                        currentCastTimerSpace = 0;
                        castingmagicSpace = true;
                        charges_used_Space = 0;
                        buffer_Space = 0;
                        Cooldowns cd = UI.GetComponent<Cooldowns>();
                        cd.CD_Space(spell[SavedData.currentDashID].Cooldown);
                    }else{
                        
                        if(buffer_Space <= 0){
                            // Add charge counter UI here !
                            charges_used_Space++;
                            buffer_Space = spell[SavedData.currentDashID].Time_Between_2_charges;
                            spellSpace();
                        }                   
                    }
            }  
        }else   
        {
            if(currentCastTimerSpace<30)currentCastTimerSpace += Time.deltaTime;
            if(buffer_Space > 0) buffer_Space -= Time.deltaTime;
            if(currentCastTimerSpace > spell[SavedData.currentDashID].Cooldown) castingmagicSpace = false;
        }
    Debug.Log(buffer_Space);
    }
#endregion    
#region Spells
    void Spell1()
    {
        Vector3 shootDir = (FirePoint.position - transform.position).normalized;
        spell[SavedData.currentSpell1ID].Activate(gameObject, spell_prefab[SavedData.currentSpell1ID] ,shootDir);

    }

    void Spell2()
    {
        Vector3 shootDir = (FirePoint.position - transform.position).normalized;
        
        spell[SavedData.currentSpell2ID].Activate(gameObject, spell_prefab[SavedData.currentSpell2ID] ,shootDir);
        //GameObject ElectroShock = Instantiate(ElectroShockPrefab, transform.position, Quaternion.identity, transform);
    }

    void Spell3()
    {

        Vector3 shootDir = (FirePoint.position - transform.position).normalized;
        spell[SavedData.currentSpell3ID].Activate(gameObject, spell_prefab[SavedData.currentSpell3ID] ,shootDir);
    
        
    }

    void spell4(){
        Vector3 shootDir = (FirePoint.position - transform.position).normalized;
        spell[SavedData.currentSpell4ID].Activate(gameObject, spell_prefab[SavedData.currentSpell4ID] ,shootDir);
    }
    void spellSpace(){
        Vector3 shootDir = (FirePoint.position - transform.position).normalized;
        spell[SavedData.currentDashID].Activate(gameObject, spell_prefab[SavedData.currentDashID] ,shootDir);
    }
#endregion


}
