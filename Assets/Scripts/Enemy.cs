#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Units/Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private float health, damage, speed;

    public string enemyName;

    public float Health { get { return health; } set {; } }
    public float Damage { get { return damage; } set {; } }
    public float Speed { get { return speed; } set {; } }
}
