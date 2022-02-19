using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu;
    public GameObject[] windows;

    private CharStats[] playerStats;

    public Text[] nameText, hpText, mpText, levelText, expText;
    public Slider[] expSlider;
    public Image[] characterImage;
    public GameObject[] charStatHolder;

    public GameObject[] statusButtons;
    public Text statusName, statusHP, statusMP, statusStr, statusDef, statusWpnEqp, statusWpnPwr, statusArmr, statusArmrPwr, statusExp;
    public Image statusImage;

    public ItemButton[] itemButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(theMenu.activeInHierarchy)
            {
                //theMenu.SetActive(false);
                //GameManager.instance.gameMenuOpen = false;
                CloseMenu();
            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;

            }
        }
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;
        for(int i = 0; i < playerStats.Length; i++)
        {
            if(playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);
                nameText[i].text = playerStats[i].charName;
                hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                mpText[i].text = "MP: " + playerStats[i].currentMP + "/" + playerStats[i].maxMP;
                levelText[i].text = "Level: " + playerStats[i].playerLevel;
                expText[i].text = "" + playerStats[i].currentEXP + " / " + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].value = playerStats[i].currentEXP;
                characterImage[i].sprite = playerStats[i].characterImage;

            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }

    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();
        for (int i = 0; i < windows.Length; i++)
        {
            if(i == windowNumber)
            {
                Debug.Log(i);
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        theMenu.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }

    public void OpenStatus()
    {
        UpdateMainStats();
        StatusChar(0);
        for(int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName;
        }
    }

    public void StatusChar(int selectedCharacter)
    {
        statusName.text = playerStats[selectedCharacter].charName;
        statusHP.text = "" + playerStats[selectedCharacter].currentHP + "/" + playerStats[selectedCharacter].maxHP;
        statusMP.text = "" + playerStats[selectedCharacter].currentHP + "/" + playerStats[selectedCharacter].maxMP;
        statusStr.text = playerStats[selectedCharacter].strength.ToString();
        statusDef.text = playerStats[selectedCharacter].defense.ToString();

        if(playerStats[selectedCharacter].equippedWeapon != "")
        {
            statusWpnEqp.text = playerStats[selectedCharacter].equippedWeapon;
        }

        statusWpnPwr.text = playerStats[selectedCharacter].weaponPower.ToString();

        if(playerStats[selectedCharacter].equippedArmor != "")
        {
            statusArmr.text = playerStats[selectedCharacter].equippedArmor;
        }

        statusArmrPwr.text = playerStats[selectedCharacter].armorPower.ToString();
        statusExp.text = (playerStats[selectedCharacter].expToNextLevel[playerStats[selectedCharacter].playerLevel] - playerStats[selectedCharacter].currentEXP).ToString();
        statusImage.sprite = playerStats[selectedCharacter].characterImage;
    }

    public void showItems()
    {
        GameManager.instance.SortItems();

        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if (GameManager.instance.itemHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItem[i].ToString();
            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

}
