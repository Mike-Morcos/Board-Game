using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] GameObject _fireTilePrefab; // Prefab to be instantiated for fire tiles
    [SerializeField] GameObject _wallTilePrefab; // Prefab to be instantiated for fire tiles
    [SerializeField] GameObject _normalTilePrefab; // Prefab to be instantiated for fire tiles
    void Start()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();

        if (playerMovement != null)
        {
            List<PointData> points = playerMovement.Points;

            // Iterate through each point and instantiate the fire tile prefab if the fireTile flag is true
            foreach (PointData pointData in points)
            {
                if (pointData.fireTile)
                {
                    Instantiate(_fireTilePrefab, pointData.Point.position, Quaternion.identity, transform);
                }
                else if (pointData.wallTile)
                {
                    Instantiate(_wallTilePrefab, pointData.Point.position, Quaternion.identity, transform);
                }
                //if (pointData.normalTile)
                //{
                //    Instantiate(_normalTilePrefab, pointData.Point.position, Quaternion.identity, transform);
                //}
                else
                {
                    Instantiate(_normalTilePrefab, pointData.Point.position, Quaternion.identity, transform);
                }


            }
        }
    }
}
