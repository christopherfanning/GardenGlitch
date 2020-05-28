using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 50;
    [SerializeField] GameObject deathVFX;


    public void DealDamage(float damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            KillGameObject();
        }
    }

    private void KillGameObject()
    {
        Destroy(gameObject);

        if (!deathVFX) { return; }
        else
        {
            Instantiate(deathVFX, transform.position, transform.rotation);

        }
    }
}
