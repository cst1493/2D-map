using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public static readonly string allyParentName = "Allies"; //name of empty parent gameObject of all player characters.
    public static bool blockSelectingChars = false;
    public static float unblockTime;

    private Vector2 targetPos, currentPos;
    private bool thisCharIsSelected = false;
    private string playerCommand = null;
    void Start()
    {
        if (speed == 0) { speed = 5.0f; }
        targetPos = transform.position;
    }

    void Update()
    {
        currentPos = transform.position; //update current position in the movement

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if ((thisCharIsSelected) && (playerCommand.Equals("move")))
            {
                UpdateTargetPos(); //move and detatch from character.
            }
            //check else if this character is selected for a command.
            else if (!blockSelectingChars && (Time.time > unblockTime))
            {
                RayHit();
            }
        }
        transform.position = Vector2.MoveTowards(currentPos, targetPos, (speed * Time.deltaTime));
    }

    private void UpdateTargetPos()
    {
        unblockTime = Time.time + 0.2f; //added delay to not allow clicking a location and another character on the same click.
        blockSelectingChars = false;
        thisCharIsSelected = false;
        playerCommand = null;
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //mouse pos relitive to camera where 0,0 is center of camera.
    }

    private void RayHit() //get mouse location, and select character if hovering over character.
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if ((hit.collider != null) && (!thisCharIsSelected)) //if hit any gameObject && not selecting destination
        {
            //if hit this gameObject and not selected on another character
            if ((hit.transform.name == this.transform.name) && (transform.parent.name.Equals(allyParentName)))
            {
                blockSelectingChars = true;
                thisCharIsSelected = true;

                playerCommand = GetPlayerCommand();
                //Debug.Log(hit.transform.name + " was clicked.");
            }
        }
    }

    private string GetPlayerCommand() //TODO let player choose what to do with character.
    {
        return "move";
    }

    /* added to character game object in editor:
     * This script.
     * Rigidbody 2D --> set to Kinematic to be able to detect collisions later.
     * Sprite Renderer added to an empty child object to change the sprite's pivot/y-coord.
     */
}
