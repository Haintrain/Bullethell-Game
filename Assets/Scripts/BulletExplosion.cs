using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    void Start()
    {
        //Destroy(gameObject, 1);
    }

    void OnEnable()
    {
        Invoke("Deactivate", 0.5f);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}