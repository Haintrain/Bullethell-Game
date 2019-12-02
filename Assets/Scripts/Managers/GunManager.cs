#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunManager : MonoBehaviour
{
    public Gun stats;

    private float lastShot;
    private int ammo;

    public float Ammo { get { return ammo; } set {; } }

    void Start()
    {
        stats.weaponName = this.name;
        ammo = stats.MagazineSize;
    }

    void Update()
    {
        if (stats.AutoFire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InvokeRepeating("Fire", 0, 1f / stats.Firerate);
            }

            if (Input.GetMouseButtonUp(0))
            {
                CancelInvoke("Fire");
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time - lastShot > 1f/stats.Firerate)
            {
                Fire();
                lastShot = Time.time;
            }
        }
    }

    void Fire()
    {
        if(ammo < 1)
        {
            //Play out of ammo sound (add)
            return;
        }
        
        Quaternion qAngle = Quaternion.AngleAxis(-stats.Projectiles / 2f * stats.Spread, -transform.forward) * transform.rotation;
        Quaternion qDelta = Quaternion.AngleAxis(stats.Spread, -transform.forward);

        qAngle *= Quaternion.AngleAxis(0.5f * stats.Spread, -transform.forward);


        //Play firing sound (add)
        ammo -= 1;

        for (var i = 0; i < stats.Projectiles; i++)
        {
            GameObject bullet = ObjectPooler.sharedInstance.GetPooledObject("Bullet");

            if (bullet != null)
            {
                bullet.transform.position = transform.parent.parent.position + transform.right * (float)1;
                bullet.transform.rotation = qAngle;

                bullet.transform.Rotate(0, 0, 90);

                //If player velocity should be added
                //Vector2.Max(transform.parent.GetComponentInParent<Rigidbody2D>().velocity + (Vector2)bullet.transform.right * stats.Speed, (Vector2)bullet.transform.right * stats.Speed);

                bullet.SetActive(true);

                bullet.GetComponent<Rigidbody2D>().velocity = -(Vector2)bullet.transform.up * stats.Speed;
            }

            qAngle = qDelta * qAngle;

            //Non pooled generation of bullets
            //GameObject bullet = Instantiate(stats.Projectile, transform.parent.parent.position + transform.right * (float)1, qAngle);          
        }
    }

    public string getName()
    {
        return name;
    }
}
