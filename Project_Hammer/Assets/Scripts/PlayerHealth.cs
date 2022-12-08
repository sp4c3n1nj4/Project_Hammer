using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Entity
{
    [SerializeField]
    private GameObject gameOverMenu;

    public override void DestroyEntity()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }
}
