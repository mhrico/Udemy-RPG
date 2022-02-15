using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int baseEXP = 1000;
    public int maxLevel = 10;
    public int[] expToNextLevel;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 100;
    public int[] mpLevelBonus;
    public int strength;
    public int defense;
    public int weaponPower;
    public int armorPower;

    public string equippedWeapon;
    public string equippedArmor;

    public Sprite characterImage;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        mpLevelBonus = new int[maxLevel];
        expToNextLevel[1] = baseEXP;
        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        if(playerLevel < maxLevel)
        {

            if(currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;

                if(playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defense++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLevelBonus[playerLevel];
                currentMP = maxMP;

            }

        }
        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
