using UnityEngine;

public struct WaypointInfo
{
    public Vector3 WayPoint { get; private set; }

    public float ArrivalTime { get; private set; }

    public WaypointInfo(Vector3 wayPoint, float arrivalTime)
    {
        WayPoint = wayPoint;
        ArrivalTime = arrivalTime;
    }
}

public class EnemyMovement : MonoBehaviour
{
    float timer;
    float arrivalTime;
    Vector3 startPosition;
    Vector3 goalPosition;
    WaypointInfo[] waypointsInfo;

    public void SetParameter(Vector3 start, Vector3 goal, float time)
    {
        startPosition = start;
        goalPosition = goal;
    }

    bool Move()
    {
        timer += Time.deltaTime;
        if (timer < arrivalTime)
        {
            transform.position = startPosition + (goalPosition - startPosition) * timer / arrivalTime;
            return false;
        }
        else
        {
            transform.position = goalPosition;
            return true;
        }
    }

    void Start()
    {
        SetParameter(new Vector3(0f, 0f, 0f), new Vector3(2f, 0f, 5f), 5f);
        startPosition = transform.position;
    }

    void Update()
    {
        if (Move() == true)
        {

        }
    }
}