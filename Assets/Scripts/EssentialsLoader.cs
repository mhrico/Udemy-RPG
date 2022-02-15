using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameManager;

    private void Awake()
    {
        if(UIFade.instance == null)
        {
            Instantiate(UIScreen);
        }
        
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }

        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }
}
