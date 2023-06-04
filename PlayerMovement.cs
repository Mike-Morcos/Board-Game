using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] List<PointData> _points; // List of points with their enabled/disabled status

    public List<PointData> Points => _points; // Public property to access the _points list

    [SerializeField] float _moveSpeed;

    bool _canMove = true; // Flag to determine if the player can move

    private void Update()
    {
        // Check for player input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Check if there is a movement direction and the player can move
        if (movementDirection != Vector3.zero && _canMove)
        {
            // Calculate the target point based on the closest point in the movement direction
            Transform newTargetPoint = GetNextPoint(movementDirection);

            // If a valid target point exists, move the player to it
            if (newTargetPoint != null)
            {
                StartCoroutine(MoveToTargetPoint(newTargetPoint));
            }
        }
    }

    private IEnumerator MoveToTargetPoint(Transform newTargetPoint)
    {
        // Disable movement temporarily
        _canMove = false;

        // Move towards the target point
        while (transform.position != newTargetPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, newTargetPoint.position, Time.deltaTime * _moveSpeed);
            yield return null;
        }

        // Enable movement after reaching the target point
        _canMove = true;
    }

    private Transform GetNextPoint(Vector3 movementDirection)
    {
        Transform closestPoint = null;
        float closestDistance = Mathf.Infinity;

        // Iterate through each point and find the closest one in the movement direction
        foreach (PointData pointData in _points)
        {
            if (pointData.wallTile)
                continue; // Skip disabled points

            Transform point = pointData.Point;
            Vector3 directionToTarget = (point.position - transform.position).normalized;
            float dotProduct = Vector3.Dot(directionToTarget, movementDirection);

            if (dotProduct > 0f)
            {
                // Check if the movement direction is towards one of the four cardinal directions (up, down, left, right)
                if (movementDirection == Vector3.up && directionToTarget == Vector3.up)
                {
                    float distance = Vector3.Distance(transform.position, point.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestPoint = point;
                    }
                }
                else if (movementDirection == Vector3.down && directionToTarget == Vector3.down)
                {
                    float distance = Vector3.Distance(transform.position, point.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestPoint = point;
                    }
                }
                else if (movementDirection == Vector3.left && directionToTarget == Vector3.left)
                {
                    float distance = Vector3.Distance(transform.position, point.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestPoint = point;
                    }
                }
                else if (movementDirection == Vector3.right && directionToTarget == Vector3.right)
                {
                    float distance = Vector3.Distance(transform.position, point.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestPoint = point;
                    }
                }
            }
        }

        return closestPoint;
    }
}

[System.Serializable]
public class PointData
{
    public Transform Point;
    public bool wallTile = false;
    public bool fireTile = false;
    public bool normalTile = false;
}


