using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;

    public float Damage { get { return damage; } set { damage = value; } }

    void BulletHit()
    {
        GameObject bulletExplosion = ObjectPooler.sharedInstance.GetPooledObject("Bullet Explosion");

        if (bulletExplosion != null)
        {
            bulletExplosion.transform.position = gameObject.transform.position;

            bulletExplosion.SetActive(true);
        }

        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().currentHealth -= damage;
        }

        BulletHit();
    }
}
