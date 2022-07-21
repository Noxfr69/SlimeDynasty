using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3(0,0.6f,0);
    public Vector3 RandmizeIntensity = new Vector3(0.5f,0.2f,0);


    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.position += Offset;
        transform.position += new Vector3(
        Random.Range(-RandmizeIntensity.x, RandmizeIntensity.x),
        Random.Range(-RandmizeIntensity.y, RandmizeIntensity.y),
        Random.Range(-RandmizeIntensity.z, RandmizeIntensity.z)    
        );

    }

}
