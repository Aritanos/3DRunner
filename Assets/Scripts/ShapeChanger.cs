using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shape changer
public class ShapeChanger : MonoBehaviour
{
    [SerializeField]
    private float changeValue;

    [SerializeField]
    private GameObject body;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightLeg;
    [SerializeField]
    private GameObject leftLeg;

    private void Awake()
    {
        Food.onScoreIncrease += ChangeShape;
        Wall.onScoreDecrease += ChangeShape;
    }

    public void ChangeShape(int score)
    {
            leftLeg.transform.localScale += score * changeValue * 1.2f * new Vector3(1, 0, 1);
            rightLeg.transform.localScale += score * changeValue * 1.2f * new Vector3(1, 0, 1);
            body.transform.localScale += score * changeValue * 0.5f * new Vector3(1, 0, 1);
            leftHand.transform.localScale += score * changeValue * 0.25f * new Vector3(1, 1, 0);
            rightHand.transform.localScale += score * changeValue * 0.25f * new Vector3(1, 1, 0);
    }

    private void OnDestroy()
    {
        Food.onScoreIncrease -= ChangeShape;
        Wall.onScoreDecrease -= ChangeShape;
    }
    //private void
}
