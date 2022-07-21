using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
public enum SpawnState { SPAWNING, WAITING, COUNTING};
public SpawnState state = SpawnState.WAITING;
public List<Wave> currentWave = new List<Wave>();
public List<GameObject> monsters = new List<GameObject>();
public string Name;
public int CurrentWaveLevel = 0;
public int currentWaveMonster = 0;
public Vector3 spawnPoint;
public GameObject StartWaveButton;

public int maxWaveLenght;



    private void Start() {
        Name = currentWave[CurrentWaveLevel].name;
        maxWaveLenght = currentWave[CurrentWaveLevel].waveInfo.Count;
        Debug.Log(maxWaveLenght);
        Debug.Log(CurrentWaveLevel);
        // build automatic start 
        
    }
    private void Update() 
    {

        if (state == SpawnState.SPAWNING)
        {
            StartCoroutine(Spawner(CurrentWaveLevel));
            CurrentWaveLevel++;
        }
        
    }


    public void OnClickStartTheWave()
    {
        StartWaveButton.SetActive(false);
        state = SpawnState.SPAWNING;
    }

    IEnumerator Spawner(int CurrentWaveLevel)
    {
        state = SpawnState.COUNTING;
        maxWaveLenght = currentWave[CurrentWaveLevel].waveInfo.Count;
        for (int currentWaveMonster = 0; currentWaveMonster < maxWaveLenght; currentWaveMonster++)
        {
            Instantiate(monsters[currentWave[CurrentWaveLevel].waveInfo[currentWaveMonster]],spawnPoint,Quaternion.identity);
            yield return new WaitForSeconds(currentWave[CurrentWaveLevel].rate);
        }
        
        state = SpawnState.WAITING;
        StartWaveButton.SetActive(true);


       yield break; 
    }
}


//   Instantiate(monsters[currentWave[CurrentWaveLevel].waveInfo[currentWaveMonster]],spawnPoint,Quaternion.identity);