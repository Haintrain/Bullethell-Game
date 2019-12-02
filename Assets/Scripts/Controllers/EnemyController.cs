using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Enemy stats;
    public Text enemyText;

    public string enemyName;
    public float currentHealth;
   
    void Start()
    {
        enemyName = stats.name;
        currentHealth = stats.Health;
    }

    void FixedUpdate()
    {
        enemyText.text = enemyName + " HP: " + currentHealth;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy is dead");
        Destroy(this.gameObject);
    }
}
