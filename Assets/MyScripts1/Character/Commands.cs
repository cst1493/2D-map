using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    public static readonly string Allies = "Allies"; //name of empty parent gameObject of all player characters.  Might use object's Tag instead.
    public static readonly string Enemies = "Enemies";

    private Vector2 targetPos;
    private bool objectsSelectable;
    private string playerCommand;
    private bool charSelected;

    //selected object and list of commands for selected objects.
    private GameObject selectedGameObject;
    private string moveAlly = "moveAlly";
    private string cancel = "cancel";

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
            {
                selectedGameObject = RayHit();
                if (selectedGameObject != null) PlayerSelectsGameObjectFeedback();
            }
            else if (charSelected /* && commandSelected*/)
            {
                CommandCharacter();
            }
        }
    }

    private void CommandCharacter() //keeps looping through if playerCommand == null.
    {
        if (playerCommand.Equals(moveAlly))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //mouse pos relitive to camera where 0,0 is center of camera.
            selectedGameObject.GetComponent<States>().Move(targetPos);

            DeselectCharacter();
        }
        else if (playerCommand.Equals(cancel)) { DeselectCharacter(); }
    }
    private GameObject RayHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); //get object on mouse position
        if ((hit.collider != null) && (objectsSelectable)) //if hit any gameObject
        {
            //Debug.Log(hit.transform.name + " was clicked.");
            objectsSelectable = false;
            charSelected = true;
            return hit.transform.gameObject;
        }
        return null;
    }
    private void PlayerSelectsGameObjectFeedback() //Player selects what to do after selecting a character or base.
    {
        if (selectedGameObject.transform.parent.name.Equals(Allies)) { //or search by tag with --> if (selectedGameObject.tag == "Player")
            Debug.Log("Ally Selected.  TODO: Allow player to select a command now.");
            playerCommand = moveAlly;
        }
        else if (selectedGameObject.transform.parent.name.Equals(Enemies)) {
            Debug.Log("Enemy Selected.  TODO: Show enemy details.");
            playerCommand = cancel;
        }
        //TODO else if player selects a base or another selectable object.
        else {
            Debug.LogWarning("GameObject selected has no recognized parent name. Assumed Gameobject is not a character or a base.  Deselecting object.");
            playerCommand = cancel; 
        }
    }
    private void DeselectCharacter() {
        playerCommand = null;
        charSelected = false;
        objectsSelectable = true;
    }

}
