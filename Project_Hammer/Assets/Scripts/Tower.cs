using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Entity
{
    public float attackDelay;
    public float attackDuration;
    public float damage;
    public float range = Mathf.Infinity;

    [SerializeField]
    private bool built = false;
    [SerializeField]
    private bool engaged;
    private float attackTimer = 0;   

    public override void Update()
    {
        base.Update();

        if (!built)
            return;

        TurnTower();
        DetectEnemies();

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else if (engaged && attackTimer <= 0)
        {
            Attack();
            attackTimer = attackDelay;
        }       
    }

    private void DetectEnemies()
    {
        GameObject closestEnemy = FindClosestEnemy();

        if (closestEnemy == null)
        {
            engaged = false;
            return;
        }

        var distance = Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position);

        if (distance <= range)
            engaged = true;
        else
            engaged = false;
    }

    private GameObject FindClosestEnemy()
    {
        //get all enemies end return closest game object
        GameObject target = null;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        var distance = range;
        for (int i = 0; i < enemies.Length; i++)
        {
            var dist = Vector3.Distance(this.transform.position, enemies[i].transform.position);
            if (dist < distance)
            {
                target = enemies[i];
                distance = dist;
            }                
        }
        return target;
    }

    private void TurnTower()
    {
        if (FindClosestEnemy() == null)
            return;

        //turn character towards enemy or in movement direction
        float rotation = TargetEnemy(FindClosestEnemy());

        //slowly turn character towards intended rotation
        float lerpedRotation = Mathf.LerpAngle(rotation, gameObject.transform.rotation.eulerAngles.y, 0.5f);

        gameObject.transform.rotation = Quaternion.AngleAxis(lerpedRotation, Vector3.up);
    }


    private float TargetEnemy(GameObject target)
    {
        //calculate rotation towards target
        Vector3 targetVector = target.transform.position - this.transform.position;
        return Mathf.Rad2Deg * Mathf.Atan2(targetVector.x, targetVector.z);
    }

    public virtual void Attack()
    {
        throw new NotImplementedException();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (FindClosestEnemy() != null)
            Gizmos.DrawLine(FindClosestEnemy().transform.position, gameObject.transform.position);
    }
}
