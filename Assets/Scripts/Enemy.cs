using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float Speed = 10f;

    private Transform Target;
    private int WavepointIndex = 0;
    public int health = 100;
    public int value = 10;
    public GameObject deathEffect;
    
    // Start is called before the first frame update
    void Start()
    {

        Target = Waypoints.Points[WavepointIndex];

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = Target.position - transform.position;
        transform.Translate(direction.normalized * (Speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, Target.position) <= 0.4)
        {
            
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (WavepointIndex < Waypoints.Points.Length - 1)
        {
            WavepointIndex++;
            Target = Waypoints.Points[WavepointIndex];
        }
        else
        {
            EndPath();
        }
    }

    void EndPath()
    {
        PlayerStats.LoseLife();
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
        PlayerStats.AddMoney(value);
        Destroy(gameObject);
    }
}
