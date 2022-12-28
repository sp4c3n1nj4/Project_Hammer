using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null || other.isTrigger)
            return;
        if (other.transform.parent.GetComponent<Entity>())
        {
            pl.HitBoxEnter(other.transform.parent.gameObject);
        }       
    }
}
