
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Level Spawner and objects parameters
public class ProjectManager : MonoBehaviour
{
    [SerializeField]
    private FieldScaler fieldScaler;
    [SerializeField]
    private int wallsDistance;
    [SerializeField]
    private float distanceBetweenFoodRows;
    [SerializeField]
    private float distanceBetweenFoodItems;
    public const int ROWSCOUNT = 4;
    private float position;
    [SerializeField]
    private int food0Score;
    [SerializeField]
    private int food1Score;
    [SerializeField]
    private int food2Score;
    [SerializeField]
    private int playerSpeed;

    [SerializeField]
    private Wall wallPrefab;
    [SerializeField]
    private GameObject[] foodPrefabs;//3
    [SerializeField]
    private GameObject playerPrefab;


    private static ProjectManager _instance;
    public static ProjectManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;

        }

        position = distanceBetweenFoodRows;
        Time.timeScale = 1;
        if (foodPrefabs != null && distanceBetweenFoodItems != 0)
        {
            for (int i = 0; i < ProjectManager.Instance.GetFieldLength() / wallsDistance; i++)
            {
                GenerateFoodRow(wallsDistance * i);

            }
        }
    }

    public int GetRowsCount()
    {
        return ROWSCOUNT;
    }

    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }
    public float GetRowWidth()
    {
        return fieldScaler.fieldWidth / ROWSCOUNT;
    }

    public int GetFieldLength()
    {
        return fieldScaler.fieldLengthInMeters;
    }

    public int GetFieldWidth()
    {
        return fieldScaler.fieldWidth;
    }

    public int GetFoodScore(int foodType)
    {
        switch (foodType)
        {
            case 0:
                return food0Score;
            case 1:
                return food1Score;
            case 2:
                return food2Score;
            default:
                return 0;
        }
    }

    private float GenerateFoodRow(float originalPosition)
    {
        int score = 0;
        var rowNum = Random.Range(0, 4);
        var rowItemCountMax = Random.Range(4, 8);
        int rowWeight = 0;
        int rowItemCount = 0;
        float pos;
        for (pos = originalPosition + distanceBetweenFoodRows; pos < originalPosition + wallsDistance - distanceBetweenFoodRows; pos += distanceBetweenFoodItems)
        {
            if (rowItemCount < rowItemCountMax)
            {
                int foodType = Random.Range(0, 3);
                Instantiate(foodPrefabs[foodType], new Vector3(GetRowWidth() * (rowNum + 0.5f), 0, pos), Quaternion.identity, transform);
                score += Instance.GetFoodScore(foodType);
                rowItemCount++;
                rowWeight++;
            }

            else
            {
                rowNum = Random.Range(0, 4);
                rowItemCountMax = Random.Range(4, 8);
                rowItemCount = 0;
                pos += distanceBetweenFoodRows;
            }
        }

        GenerateWalls(pos, score);

        return pos;
    }

    private void GenerateWalls(float zPosition, int score)
    {

        if (wallPrefab != null )
        {
            if (Mathf.Abs(zPosition + distanceBetweenFoodRows) < fieldScaler.fieldLengthInMeters)
            {
                for (int j = 0; j < 4; j++)
                {
                    Instantiate(wallPrefab, new Vector3(fieldScaler.fieldWidth / ROWSCOUNT * (j + 0.5f), 1, zPosition + 0.5f), Quaternion.identity, transform).GetComponent<Wall>().WallSetup((int)(score * Random.Range(0.5f, 1.2f)));
                }
            }
        }

        else
        {
            Debug.LogError("Wall Prefab is null");
        }
    }
}
