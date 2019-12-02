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
        GameObject bulletExplosion = ObjectPooler.sharedInstance.GetPooledObject("Bullet Explosion");

        if (bulletExplosion != null)
        {
            bulletExplosion.transform.position = gameObject.transform.position;

            bulletExplosion.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
