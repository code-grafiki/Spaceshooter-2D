using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer= other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            EnemyHitEffect();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {   
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void EnemyHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
