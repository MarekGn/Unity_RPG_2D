using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;

    private PlayerStats thePlayerStats;

    public int expTogive;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCurrentHealth <= 0f)
        {
            Destroy(gameObject);

            thePlayerStats.AddExpirience(expTogive);
        }

    }

    public void HurtEnemy(int damageToGive)
    {
        EnemyCurrentHealth -= damageToGive;
    }

    public void setMaxHealth()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }
}
