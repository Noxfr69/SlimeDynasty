using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject Ennemie_Alive;
    private bool isActive;
    public float curent_time;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerSlime playref = collider.GetComponent<PlayerSlime>();
        if(playref != null)
        {
            Debug.Log("Win?");
            GameObject[] ennemy;
            ennemy = GameObject.FindGameObjectsWithTag("Ennemy");
            if(ennemy.Length <= 0){
                LoadNextLevel();
            }
            else
            {
                Ennemie_Alive.SetActive(true);
                isActive = true;
                curent_time = 0;

                Debug.Log("ennemie encore en vie");
            } 
        }

    }
    private void Update() {
        if(isActive){
            float cd = 2;
            curent_time += Time.deltaTime;
            if (curent_time >= cd){
                Ennemie_Alive.SetActive(false);
                isActive = false;
            }
        }
    }

    private void LoadNextLevel(){

        int currentlvl = SceneManager.GetActiveScene().buildIndex;
        Loader.Load((Loader.Scene)currentlvl + 1);

        // var a = (Loader.Scene)1;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

