using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script for controlling a projectile
/// </summary>
public class Projectile : MonoBehaviour
{
    #region Data Members
    public float moveSpeed;

    public LayerMask obstacleLayer;
    public LayerMask damageLayer;

    public int attackDamage;

    public int scoreValue;
    #endregion

    #region Unity Callbacks
    // Update is called once per frame
    void Update()
    {
        // Move the projectile
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
    }

    // OnTriggerEnter is called when the Collider other enter the trigger
    void OnTriggerEnter(Collider collision)
    {
        // Check if collided with an obstacle or an enemy
        // (Need to convert layer to layermask using the binary left-shift operator to left-shift 1 by the layer)
        if (1 << collision.gameObject.layer == obstacleLayer.value ||
            1 << collision.gameObject.layer == damageLayer.value)
        {
            // If collided with enemy, deal damage and inflict effect
            if (1 << collision.gameObject.layer == damageLayer.value)
            {
                // Get HealthController
                //HealthController _health = collision.gameObject.GetComponent<HealthController>();
                if (collision.TryGetComponent(out HealthController health))
                {
                    // Inflict attackDamage
                    health.ChangeHealth(-attackDamage);
                }
                else
                {
                    if (collision.TryGetComponent(out Projectile projectile))
                    {
                        GameController.Instance.UpdateScore(projectile.scoreValue);
                    }
                    Destroy(collision.gameObject);
                }  
            }
            // Destroy after collided with an obstacle or an enemy
            Destroy(gameObject);
        }
    }
    #endregion
}
