using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxFriendly : MonoBehaviour
{
    public Tower twr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Entity>().TakeDamage(twr.damage);
        }
    }
}
