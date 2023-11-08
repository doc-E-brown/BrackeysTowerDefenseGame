using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _wavePointIndex;
    private Enemy _enemy;
    
    
    // Start is called before the first frame update
    private void Start()
    {

        _enemy = GetComponent<Enemy>();
        _target = Waypoints.Points[_wavePointIndex];

    }
    
   // Update is called once per frame
   private void Update()
    {

        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * (_enemy.speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4)
        {
            
            GetNextWaypoint();
        }

        _enemy.speed = _enemy.startSpeed;
    }

   private void GetNextWaypoint()
    {
        if (_wavePointIndex < Waypoints.Points.Length - 1)
        {
            _wavePointIndex++;
            _target = Waypoints.Points[_wavePointIndex];
        }
        else
        {
            EndPath();
        }
    }
    private void EndPath()
    {
        PlayerStats.LoseLife();
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }


}
