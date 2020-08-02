using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization; //
using UnityEditor; // [MenuItem("xxx")]

//[System.Serializable] //To be able to edit this classes/objects and structs in Unity.
public class UnityTips : MonoBehaviour //MonoBehavior scripts are required to be connected to a game object to run.
{
    [HideInInspector]
    public string xPub = "public var hidden from inspector ^ ";

    [Header("inspector header")] //organize inspector.  [Space] adds a blank space.
    [Range(0f, 10f)] //sets a dragable bar in the inspector.
    [SerializeField] //show private var in inspector
    private string xPri = "private shown in inspector";

    [FormerlySerializedAs("hp")] //to rename serialized data from using Serialization above.
    public int health = 10;



    void Start()
    {
        
    }

    void Update()
    {
        if (health == 9)
        {
            Debug.Log("<color=red>Red text,</color>" + "normal text"); //colored Debug.
        }
    }

    [ContextMenu("MyMenu")] //to put access to run method in inspector for testing a method.  //[MenuItem("MyMenu")] to add to top navbar. //using UnityEditor; 
    void TestMethodAttachedToObjectsInspector()
    {
        Debug.Log("clicked MyMenu on top of editor or inspector to run method while playing.");
        EditorApplication.isPaused = true; //pause game.
    }
}
/*
 * Use "Kinematic Rigidbody Trigger Colliders" for overhead characters to ignore physics on collision (not "Kinematic Rigidbody Colliders").  Triggers/set-to-true when colliding.
 * 
 * 
 * 
 * */
