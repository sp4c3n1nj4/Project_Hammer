using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }
}