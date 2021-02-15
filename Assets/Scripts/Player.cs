using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player movement 
public class Player : MonoBehaviour
{
    //[SerializeField]
    //private float speed;
    private bool isMoved = false;

    [SerializeField]
    private int currentRow = 2;

    private void FixedUpdate()
    {
        MovePlayer(ProjectManager.Instance.GetPlayerSpeed() * Time.deltaTime * Vector3.forward);
    }

    private void Update()
    {
        MobileTouchMoving();
        PCMoving();
    }

    private void Start()
    {
        transform.position = new Vector3(ProjectManager.Instance.GetRowWidth()*1.5f, 0, 0.2f);
    }

    private Vector2 originalPos = Vector2.zero;
    private void MobileTouchMoving()
    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        originalPos = touch.position;
                    }
                    break;
                case TouchPhase.Moved:
                    {

                        if (touch.position.x > originalPos.x + 5f && currentRow < ProjectManager.Instance.GetRowsCount())
                        {
                            MovePlayer(1);
                        }

                        else if (touch.position.x < originalPos.x - 5f && currentRow > 1)
                        {
                            MovePlayer(-1);
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    {
                        isMoved = false;
                    }
                    break;
            }
        }
        
    }

    private void PCMoving()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentRow < ProjectManager.Instance.GetRowsCount())
        {
            MovePlayer(1);
        }

        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentRow > 1)
        {
            MovePlayer(-1);
        }

    }

    private void MovePlayer(Vector3 moveVector)
    {
        transform.Translate(moveVector);
    }

    private void MovePlayer(int direction)
    {
        if (!isMoved)
        {
            transform.Translate(Vector3.right * ProjectManager.Instance.GetRowWidth() * direction);
            Camera.main.transform.Translate(Vector3.right * ProjectManager.Instance.GetRowWidth() * -direction);
            currentRow += direction;
        }
        
        isMoved = true;
    }
}
