using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private string currentState;
    private Vector2 targetPos;
    private Vector2 currentPos;
    void Start()
    {
        if (speed == 0) { speed = 5.0f; }
        targetPos = transform.position;
    }

    void Update()
    {
        //TODO if (collition with enemy) {(/*static*/ playerAllyFighter) = thisCharacter;}
        if (currentState == "moving")
            Moving();
    }

    private void Moving()
    {
        currentPos = transform.position; //update current position in the movement
        transform.position = Vector2.MoveTowards(currentPos, targetPos, (speed * Time.deltaTime));

        if (currentPos == targetPos) currentState = null;
    }

    public void Move(Vector2 targetPosition) //SelectCharacter.cs --> selectedGameObject.GetComponent<States>().Move(targetPos);
    {
        targetPos = targetPosition;
        currentState = "moving";
    }
}
