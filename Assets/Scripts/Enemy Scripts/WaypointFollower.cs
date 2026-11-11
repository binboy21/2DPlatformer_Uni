using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform waypoint1, waypoint2;
    private bool first;

    private float speed = 4f;
    
    void Start()
    {
        first = false;
    }

    void Update()
    {
        if (first)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint1.position, speed * Time.deltaTime);
            if (transform.position == waypoint1.position) first = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint2.position, speed * Time.deltaTime);
            if (transform.position == waypoint2.position) first = true;
        }
    }
}
