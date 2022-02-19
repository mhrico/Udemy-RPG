using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingActive;

    public string[] itemHeld;
    public int[] numberOfItem;
    public Item[] referenceItem;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpen || dialogActive || fadingActive)
        {
            PlayerController.instance.canMove = false;

        }
        else
        {
            PlayerController.instance.canMove = true;

        }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for (int i = 0; i < referenceItem.Length; i++)
        {
            if (referenceItem[i].itemName == itemToGrab)
            {
                return referenceItem[i];
            }
        }
        return null;
    }

    public void SortItems()
    {
        bool itemAfterSpace = true;
        while (itemAfterSpace)
        {
            itemAfterSpace = false;
            for (int i = 0; i < itemHeld.Length-1; i++)
            {
            
                if(itemHeld[i] == "")
                {
                    itemHeld[i] = itemHeld[i + 1];
                    itemHeld[i + 1] = "";

                    numberOfItem[i] = numberOfItem[i + 1];
                    numberOfItem[i + 1] = 0;

                    if(itemHeld[i] != "")
                    {
                        itemAfterSpace = true;
                    }
                }
            }
        }
    }
}
