using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Food behavior
public class Food : MonoBehaviour
{
    public delegate void OnScoreIncrease(int score);
    public static event OnScoreIncrease onScoreIncrease;

    [SerializeField]
    private int foodType;
    [SerializeField]
    private int score;
    [SerializeField]
    private int rotation;
    [SerializeField]
    private float position;

    private void Start()
    {
        FoodSetup();
    }

    private void FoodSetup()
    {
        score = ProjectManager.Instance.GetFoodScore(foodType);
        transform.Rotate(rotation, 0, 0);
        transform.Translate(Vector3.up * position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onScoreIncrease(score);
            Destroy(this.gameObject);
        }
    }
}
