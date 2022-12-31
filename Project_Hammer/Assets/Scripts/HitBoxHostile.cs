using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHostile : MonoBehaviour
{
    public Enemy enm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            other.gameObject.GetComponent<Entity>().TakeDamage(enm.damage);
        }

        if (other.gameObject.CompareTag("Tower") && !other.isTrigger)
        {
            other.gameObject.GetComponentInParent<Entity>().TakeDamage(enm.damage);
        }
    }
}
