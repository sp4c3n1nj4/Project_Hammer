using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxFriendly : MonoBehaviour
{
    public Tower twr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !other.isTrigger)
        {
            other.gameObject.GetComponentInParent<Entity>().TakeDamage(twr.damage);
        }
    }
}
