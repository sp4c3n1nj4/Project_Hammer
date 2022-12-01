using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    private Collider hitBox;

    public override void Attack()
    {
        StartCoroutine(AttackCoroutine(attackDuration));
    }

    IEnumerator AttackCoroutine(float duration)
    {
        hitBox.enabled = true;
        yield return duration;
        hitBox.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
