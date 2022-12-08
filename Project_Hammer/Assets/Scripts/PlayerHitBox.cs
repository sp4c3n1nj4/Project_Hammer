using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pl;

    private void OnTriggerEnter(Collider other)
    {
        pl.HitBoxEnter(other);
    }
}
