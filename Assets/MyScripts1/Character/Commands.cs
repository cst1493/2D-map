using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    public static readonly string allyParentName = "Allies"; //name of empty parent gameObject of all player characters.
    private float unblockTime = 0.5f;
    private bool blockSelectingChars = false;


    private Vector2 targetPos, currentPos;
    private bool objectsSelectable;
    private string playerCommand;
    private bool charSelected;


    private GameObject selectedGameObject;

    void Start()
    {
        objectsSelectable = true;
        charSelected = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (objectsSelectable) //attempt to select gameObject
                selectedGameObject = RayHit();
            else if (charSelected)
            {
                CommandCharacter();
            }
        }
    }


    private void CommandCharacter()
    {
        playerCommand = "move"; //temp.  playerCommand = GetPlayerCommand(); //enable UI to select command.

        if (playerCommand == "move")
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //mouse pos relitive to camera where 0,0 is center of camera.
            selectedGameObject.GetComponent<States>().Move(targetPos);

            DeselectCharacter();
        }
        else if (playerCommand == "cancel") { return; }

    }
    private GameObject RayHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); //get object on mouse position
        if ((hit.collider != null) && (objectsSelectable)) //if hit any gameObject
        {
            Debug.Log(hit.transform.name + " was clicked.");
            objectsSelectable = false;
            charSelected = true;
            return hit.transform.gameObject;
        }
        return null;
    }
    private void DeselectCharacter()
    {
        playerCommand = null;
        charSelected = false;
        objectsSelectable = true;
    }
}
