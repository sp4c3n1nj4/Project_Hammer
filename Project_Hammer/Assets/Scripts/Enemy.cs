using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;

    [SerializeField]
    private GameObject HealthBar;

    private GameObject bar;
    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }

    private void Awake()
    {
        bar = Instantiate(HealthBar, GameObject.FindGameObjectWithTag("UICanvas").transform);
        bar.GetComponent<HealthBar>().parentObject = gameObject;
    }

    private void OnDestroy()
    {
        Destroy(bar);
    }
}
