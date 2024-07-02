using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageValue = 10;

    public int GetDamage()
    {
        return damageValue;
    }

    //destroy the "enemy" as the player collides
    public void Hit()
    {
        Destroy(gameObject);
    }
}
