using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Wall behavior, if score < 0 - destroy 
public class Wall : MonoBehaviour
{
    public delegate void OnScoreDecrease(int score);
    public static OnScoreDecrease onScoreDecrease;

    [SerializeField]
    private float scoreChangeTimeRate;
    [SerializeField]
    private Canvas UICanvas;

    private int score;
    private float originalTime;
    private void Start()
    {

    }

    public void WallSetup(int score)
    {
        this.score = score;
        UICanvas.GetComponentInChildren<TMP_Text>().text = score.ToString();
    }

    private void Update()
    {
        if (score == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            originalTime = Time.time;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time > originalTime + scoreChangeTimeRate)
            {
                
                DecreaseScore();
                originalTime = Time.time;
            }
        }
    }

    private void DecreaseScore()
    {
        score--;
        UICanvas.GetComponentInChildren<TMP_Text>().text = score.ToString();
        onScoreDecrease(-1);
    }
}
