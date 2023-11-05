using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    
    public float startSpeed = 10f;
    public float health = 100;
    public int worth = 10;
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
        PlayerStats.AddMoney(worth);
        Destroy(gameObject);
    }
    
    public void Slow(float amount)
    {
       speed = startSpeed * (1f - amount);
    }
}
