using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float Speed = 10f;

    private Transform Target;

    private int WavepointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log($"Num waypoints {Waypoints.Points.Length}");
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
        if (WavepointIndex <= Waypoints.Points.Length - 1)
        {
            WavepointIndex++;
            Target = Waypoints.Points[WavepointIndex];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
