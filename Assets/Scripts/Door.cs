using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]string key;
    [SerializeField] int angle;
    [SerializeField]GameObject rotationPoint;

    [SerializeField]bool isUnlocked = false, isOpen = false;
    //Checks if the player has the appropriate key to open the door
    public void checkKey(List<string> keys)
    {
        foreach (string key in keys)
        {
            if(key == this.key)
            {
                Debug.Log("Door Unlocked");
                isUnlocked = true;
                toggleDoor();
                return;
            }
        }
        Debug.Log("You do not have the required key");  
    }
    //Checks the current state of the door and turns it to the opposite
    //Opens and closes the door
    public void toggleDoor()
    {
        //Debug.Log("THE GOD DAMN DOOR IS MOTHERFUCKING OPEN PLEASE FOR THE LOVE OF GOD DAMN SHIT MOTHERFUCKER");
        if(!isOpen)
        {
            rotationPoint.transform.Rotate(new Vector3(0,0,angle));
            isOpen = true;
        }
        else if(isOpen)
        {
            rotationPoint.transform.Rotate(new Vector3(0,0,-angle));
            isOpen = false;
        }
    }
    //Gets the key needed to open the door
    public string getKey()
    {
        return key;
    }
    //Checks if the door is unlocked
    public bool m_isUnlocked()
    {
        return isUnlocked;
    }
}
