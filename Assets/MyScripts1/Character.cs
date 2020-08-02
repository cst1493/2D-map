using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ScriptableObject 
    //ScriptableObject so this doesn't have to be connected to a game object, and so instances of this object can be created once per character.  
    //This isn't updated per tick and only holds the character's information.
{
    public string allyName;
    public float speed;
    public float energy; //percent or value???
    public string state; //sleeping, atBase, or awake.
    public GameObject sprite;

    /*
     * TODO: use this object to hold all of the overhead character's unique information and set Movement.cs to call Character.name to select that character.
     * There needs to be something that creates an instance of Character on startup.  Eventually creating a Character instance would 
     * be called from the save file, along with a Character child objects that are individual fighters within the party.
     * 
     * Startup methods needed:
     * 
     * Character[10] player[0] = CreateNewCharacter(Vector3 startingPoint, string saveFile);
     * Array of Characters with a length equal to the max amount of characters.
     * 
     * setPlayersState(public static string default);
     * Player mouse needs to have a state, starting with a "default" state that allows selecting characters & menu stuff.  When an ally is selected, state is 
     * set to "allySelected" with a string with the selected ally's name.
     */
}
