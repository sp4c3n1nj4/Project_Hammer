using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHostile : MonoBehaviour
{
    public Enemy enm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Tower"))
        {
            other.gameObject.GetComponent<Entity>().TakeDamage(enm.damage);
        }
    }
}
