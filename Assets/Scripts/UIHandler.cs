using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{
    [SerializeField]bool isTutorial;
    [SerializeField]TextMeshProUGUI interactText;
    [SerializeField]TextMeshProUGUI contents;
    [SerializeField]GameObject interactPane;
    [SerializeField]TextMeshProUGUI ammoCounter;
    [SerializeField]Image batteryLevel;

    [SerializeField]Image healthBar;
    [SerializeField]GameObject HealthPanel;
    void Start()
    {
        if(isTutorial)
        {
            Tutorial(false);
        }
    }
    //Turns off the player hud for the tutorial
    public void Tutorial(bool tutorialActiveState)
    {
            HealthPanel.SetActive(tutorialActiveState);
            ammoCounter.gameObject.SetActive(tutorialActiveState);
            batteryLevel.gameObject.SetActive(tutorialActiveState);
            contents.gameObject.SetActive(tutorialActiveState);
    }
    //Writes the interaction text based on the object and its contents
    public void setInteractText(bool isActive, GameObject interactName)
    {
        interactText.gameObject.SetActive(isActive);
        interactPane.SetActive(isActive);
        contents.gameObject.SetActive(isActive);
        interactText.text = "Press E to Interact with " + interactName.gameObject.name;
        Intractable temp = interactName.GetComponent<Intractable>();
        if(temp != null)
            contents.text = "Contents \n" + "Bullets " + temp.getBulletCount() + "\n Batteries " + temp.getBatteryCount() + "\n Health " +temp.getHealthCount() + "\n Keys | " + temp.getKey();
        
    }
    //Writes the interact text if there is a door in the path of the player
    public void setInteractText(bool isActive, GameObject interactName, List<string> keys)
    {
        contents.gameObject.SetActive(false);
        interactPane.SetActive(isActive);
        interactText.gameObject.SetActive(isActive);
        bool canOpenDoor = false;
        Door doorTemp = interactName.GetComponent<Door>();
        if(doorTemp != null)
        {
            foreach (string key in keys)
            {
                if(doorTemp.getKey().Equals(key))
                    canOpenDoor = true;
            }
            if(canOpenDoor == true)
                interactText.text = "You Can Open The Door";
            else
                interactText.text = "You Cannot Open The Door \nFind The " + doorTemp.getKey() + " Key";
        }
    }
    //Toggles the interact text panel
    public void setInteractText(bool isActive)
    {
        interactText.gameObject.SetActive(isActive);
        interactPane.SetActive(isActive);
        contents.gameObject.SetActive(isActive);
    }
    //Sets up the tutorial interaction text
    public void setTutorialInteraction(bool isActive, string tutoralText)
    {
        Debug.LogWarning("Setting Tutorial Text");
        interactPane.SetActive(isActive);
        interactText.gameObject.SetActive(isActive);
        interactText.text = tutoralText;
    }
    // Updates the bullet counter
    public void updateBullets(int ammoInGun, int ammoOnPlayer)
    {
        ammoCounter.text = ammoInGun + " / " + ammoOnPlayer;
    }
    //Updates the battery bar
    public void updateBattery(float currentLevel)
    {
        batteryLevel.fillAmount = currentLevel/100;
    }
    //Updates the health bar
    public void updateHealth(float currentHealth)
    {
        healthBar.fillAmount = currentHealth/100;
    }
    //Sets the tutorial boolean
    public void setIsTutorial(bool isTutorial)
    {
        this.isTutorial = isTutorial;
    }
    //Returns the tutorial boolean
    public bool getIsTutorial()
    {
        return isTutorial;
    }
}
