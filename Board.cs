using UnityEngine;
using TMPro;

public class Board : MonoBehaviour
{
    [SerializeField] int rows = 9;
    [SerializeField] int columns = 9;
    [SerializeField] float distanceBetweenPoints = 1.0f;
    [SerializeField] Vector3 startPosition = Vector3.zero;
    [SerializeField] GameObject pointPrefab;

    private GameObject[,] pointsArray;

    void Start()
    {
        // Create the _points array
        pointsArray = new GameObject[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = startPosition + new Vector3(i * distanceBetweenPoints, j * distanceBetweenPoints, 0.0f);
                pointsArray[i, j] = Instantiate(pointPrefab, position, Quaternion.identity);

                // Add a TextMeshPro component to the pointPrefab
                TextMeshPro label = pointsArray[i, j].GetComponentInChildren<TextMeshPro>();
                if (label != null)
                {
                    label.text = string.Format("{0},{1}", i, j);
                }
            }
        }
    }
}
