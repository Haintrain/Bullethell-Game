using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        //Destroy(gameObject, 1);
    }

    void OnEnable()
    {
        Invoke("Deactivate", 1);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
