using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;

    public string enemyQuestName;

    private QuestManager theQM;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();
        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCurrentHealth <= 0f)
        {
            theQM.enemyKilled = enemyQuestName;

            Destroy(gameObject);

            thePlayerStats.AddExpirience(expToGive);
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
