using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script for controlling a Knight Enemy
/// </summary>
public class KnightEnemy : Enemy
{
    // Method for attacking (Melee)
    public override void Attack()
    {
        // Array of all Colliders in damageLayer caught in Range.
        Collider[] colliders = Physics.OverlapSphere(attackOrigin.position, attackRadius, damageLayer);
        foreach (Collider collider in colliders)
        {
            HealthController health = collider.GetComponent<HealthController>();
            // Deal damage
            health.ChangeHealth(-attackDamage);
        }
    }
}
