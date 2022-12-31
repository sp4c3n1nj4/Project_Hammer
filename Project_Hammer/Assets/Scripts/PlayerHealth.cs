using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Entity
{
    [SerializeField]
    private GameObject gameOverMenu;

    public override void DestroyEntity()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
