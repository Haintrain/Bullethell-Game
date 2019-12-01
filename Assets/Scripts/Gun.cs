using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName ="Weapons/Guns")]
public class Gun : ScriptableObject
{
    [SerializeField]
    private float firerate, spread, speed;
    [SerializeField]
    private int projectiles, magazineSize;
    [SerializeField]
    private bool autoFire = false;
    [SerializeField]
    private GameObject projectile;

    public float Firerate { get { return firerate; } set {; } }
    public float Spread { get { return spread; } set {; } }
    public float Speed { get { return speed; } set {; } }
    public int Projectiles { get { return projectiles; } set {; } }
    public int MagazineSize { get { return magazineSize; } set {; } }
    public bool AutoFire { get { return autoFire; } set {; } }
    public GameObject Projectile { get { return projectile; } set {; } }

    public string weaponName;
}
