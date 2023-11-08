using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    
    public float startSpeed = 10f;
    private float _health = 100;
    public float maxHealth = 100;
    public int worth = 10;
    public GameObject deathEffect;

    [Header("Unity Stuff")] public Image healthBar;

    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        _health = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        _health -= damage;

        healthBar.fillAmount = _health / maxHealth; 

        if (_health <= 0f && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
        PlayerStats.AddMoney(worth);
        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);

        isDead = true;
    }
    
    public void Slow(float amount)
    {
       speed = startSpeed * (1f - amount);
    }
}
