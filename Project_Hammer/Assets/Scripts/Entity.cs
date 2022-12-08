using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private GameObject HealthBar;

    private GameObject bar;

    public float health;
    public float maxHealth;

    public virtual void Update()
    {
        if (health <= 0)
        {
            DestroyEntity();
        }
    }

    public virtual void DestroyEntity()
    {
        Destroy(gameObject);
    }

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
