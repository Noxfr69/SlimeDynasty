using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i {
        get{
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    [Header("Input")]
    public GameObject InputManager;
    [Header("Player")]
    public GameObject PlayerSlime;
    public GameObject SlimeAnimator;
    [Header("UI")]
    public GameObject UI;
    public Sprite test;
    






}
