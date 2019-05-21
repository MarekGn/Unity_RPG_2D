using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;

    public int currentEXP;

    public double[] toLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager thePlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        toLevelUp[0] = 0;
        toLevelUp[1] = 15;

        HPLevels[0] = 50;
        HPLevels[1] = 50;

        attackLevels[0] = 5;
        attackLevels[1] = 5;

        defenceLevels[0] = 0;
        defenceLevels[1] = 0;

        for (int i = 2; i < 500; i++)
        {
            toLevelUp[i] = (int)(15 * Mathf.Pow(i,2));
            HPLevels[i] = (int)(45 + 5 * i);
            attackLevels[i] = (int)(3 * i);
            defenceLevels[i] = (int)(i);
        }

        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEXP >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
    }

    public void AddExpirience(int experienceToAdd)
    {
        currentEXP += experienceToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];
        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }
}
