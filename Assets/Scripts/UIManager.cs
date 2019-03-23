using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    private PlayerStats thePS;
    public Text levelText;
    public Text levelToGoText;
    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP " + playerHealth.playerCurrentHealth + " / " + playerHealth.playerMaxHealth;
        levelText.text = "Lvl: " + thePS.currentLevel;
        levelToGoText.text = "Next level Exp: " + (thePS.toLevelUp[thePS.currentLevel] - thePS.currentEXP); 


    }
}
