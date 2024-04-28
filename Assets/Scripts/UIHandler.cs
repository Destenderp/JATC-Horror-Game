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
    [SerializeField]TextMeshProUGUI batteryLevel;

    [SerializeField]Image healthPanel;
    [SerializeField]GameObject HealthPanel;
    void Start()
    {
        if(isTutorial)
        {
            Tutorial(false);
        }
    }
    public void Tutorial(bool tutorialActiveState)
    {
            HealthPanel.SetActive(tutorialActiveState);
            ammoCounter.gameObject.SetActive(tutorialActiveState);
            batteryLevel.gameObject.SetActive(tutorialActiveState);
            contents.gameObject.SetActive(tutorialActiveState);
    }
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
    public void setInteractText(bool isActive)
    {
        interactText.gameObject.SetActive(isActive);
        interactPane.SetActive(isActive);
        contents.gameObject.SetActive(isActive);
    }
    public void setTutorialInteraction(bool isActive, string tutoralText)
    {
        Debug.LogWarning("Setting Tutorial Text");
        interactPane.SetActive(isActive);
        interactText.gameObject.SetActive(isActive);
        interactText.text = tutoralText;
    }
    public void setTutorialInteraction(bool isActive)
    {
        interactPane.SetActive(isActive);
        interactText.gameObject.SetActive(isActive);
    }
    public void updateBullets(int ammoInGun, int ammoOnPlayer)
    {
        ammoCounter.text = ammoInGun + " / " + ammoOnPlayer;
    }
    public void updateBattery(int currentLevel)
    {
        batteryLevel.text = currentLevel +" / "+ 100;
    }
    public void updateHealth(float currentHealth)
    {
        healthPanel.fillAmount = currentHealth/100;
    }
    public TextMeshProUGUI getAmmoCounter()
    {
        return ammoCounter;
    }
    public void setIsTutorial(bool isTutorial)
    {
        this.isTutorial = isTutorial;
    }
    public bool getIsTutorial()
    {
        return isTutorial;
    }
}
