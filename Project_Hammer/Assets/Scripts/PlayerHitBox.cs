using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !other.isTrigger)
        {
            other.gameObject.GetComponentInParent<Entity>().TakeDamage(pl.damage);
        }

        if (other.gameObject.CompareTag("Tower") && !other.isTrigger)
        {
            other.gameObject.GetComponentInParent<Entity>().TakeDamage(- pl.damage);
        }
    }
}
