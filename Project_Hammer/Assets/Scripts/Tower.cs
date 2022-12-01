using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float attackDelay;
    public float attackDuration;
    public float damage;
    public float range;

    private bool built;
    private bool engaged;
    private float attackTimer;

    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            DestroyTower();
        }

        if (!built)
            return;

        DetectEnemies();
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (engaged && attackTimer <= 0)
            {
                Attack();
                attackTimer = attackDelay;
            }
        }     
    }

    private void DestroyTower()
    {
        Destroy(gameObject);
    }

    private void DetectEnemies()
    {
        var distance = Vector3.Distance(FindClosestEnemy().transform.position, gameObject.transform.position);

        if (distance <= range)
            engaged = true;
        else
            engaged = false;
    }

    private GameObject FindClosestEnemy()
    {
        //get all enemies end return closest game object
        GameObject target = null;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        var distance = range;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, enemies[i].transform.position) < distance)
                target = enemies[i];
        }

        return target;
    }

    private void BeingBuild()
    {

    }

    public virtual void Attack()
    {
        throw new NotImplementedException();
    }
}
