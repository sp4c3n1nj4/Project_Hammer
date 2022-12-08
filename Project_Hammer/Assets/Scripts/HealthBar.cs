using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject parentObject;

    [SerializeField]
    private Image fillBar;

    private void Update()
    {
        UpdateFillAmount();
        MoveBar();
    }

    private void UpdateFillAmount()
    {
        fillBar.fillAmount = GetFillAmount();
    }

    private float GetFillAmount()
    {
        float fill = 1;

        if (parentObject.GetComponent<Enemy>())
        {
            fill = parentObject.GetComponent<Enemy>().health / parentObject.GetComponent<Enemy>().maxHealth;
        }
        else if (parentObject.GetComponent<Tower>())
        {
            fill = parentObject.GetComponent<Tower>().health / parentObject.GetComponent<Tower>().maxHealth;
        }

        return fill;
    }

    private void MoveBar()
    {
        gameObject.transform.position = parentObject.transform.position + Vector3.up * 2;
    }
}
