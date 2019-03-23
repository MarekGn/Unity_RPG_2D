using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;

    public int currentEXP;

    public double[] toLevelUp;



    // Start is called before the first frame update
    void Start()
    {
        toLevelUp[0] = 0;
        toLevelUp[1] = 15;
        for(int i = 2; i < 500; i++)
        {
                toLevelUp[i] = (int)(15 * Mathf.Pow(i,2));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEXP>= toLevelUp[currentLevel])
        {
            currentLevel++;
        }
    }

    public void AddExpirience(int experienceToAdd)
    {
        currentEXP += experienceToAdd;
    }
}
