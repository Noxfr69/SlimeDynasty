using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Fireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    // Start is called before the first frame update
    void Start()
    {
       PlayerSlime playref = GetComponentInParent<PlayerSlime>();
        playref.transform.position = Vector3.MoveTowards(playref.transform.position , FirePoint.direction , 400 * Time.deltaTime);
        TrailRenderer trailRenderer = GetComponentInParent<TrailRenderer>();
        trailRenderer.emitting = false;
        float radius = 0.5f;
        int amountToSpawn = 8;
        for (int i = 0; i < amountToSpawn; i++)
        {
            float angle = i * Mathf.PI*2f / amountToSpawn;
            Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, Mathf.Sin(angle)*radius, 0);
            GameObject fireballTransfrom = Instantiate(fireballPrefab, playref.transform.position, Quaternion.identity);
            fireballTransfrom.GetComponent<fireball>().Setup(newPos);
        }        
        playref.SaveDir();
        Destroy(gameObject,1f);
    }


}
