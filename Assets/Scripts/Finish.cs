using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Finish behavior
public class Finish : MonoBehaviour
{

    public delegate void OnFinish();
    public static event OnFinish onFinish;

    private void Awake()
    {
        transform.localScale += (ProjectManager.Instance.GetFieldWidth() - transform.localScale.x) * Vector3.right;
        transform.position =  new Vector3(ProjectManager.Instance.GetFieldWidth() / 2 , 0, ProjectManager.Instance.GetFieldLength() - transform.localScale.y/2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onFinish();
        }
    }
}
