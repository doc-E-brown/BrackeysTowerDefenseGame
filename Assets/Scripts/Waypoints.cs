using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] Points;

    private void Awake()
    {

        Points = new Transform[transform.childCount];
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] = transform.GetChild(i);
            Debug.Log($"Position of {i} waypoint is {transform.GetChild(i).position.ToString()}");
        }
        
        Debug.Log($"There are {Points.Length} points");
    }
}
