using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI interactText;
    [SerializeField]TextMeshProUGUI contents;
    [SerializeField]GameObject interactPane;
    [SerializeField]TextMeshProUGUI ammoCounter;
    [SerializeField]TextMeshProUGUI batteryLevel;

    public void setInteractText(bool isActive, GameObject interactName)
    {
        interactText.gameObject.SetActive(isActive);
        interactPane.SetActive(isActive);
        contents.gameObject.SetActive(isActive);
        interactText.text = "Press E to Interact with " + interactName.gameObject.name;
        Intractable temp = interactName.GetComponent<Intractable>();
        contents.text = "Contents \n" + "Bullets " + temp.getBulletCount() + "\n Batteries " + temp.getBatteryCount();
    }
    public void setInteractText(bool isActive)
    {
        interactText.gameObject.SetActive(isActive);
        interactPane.SetActive(isActive);
        contents.gameObject.SetActive(isActive);
    }
    public void updateBullets(int ammoInGun, int ammoOnPlayer)
    {
        ammoCounter.text = ammoInGun + " / " + ammoOnPlayer;
    }
    public void updateBattery(int currentLevel)
    {
        batteryLevel.text = currentLevel +" / "+ 100;
    }
}
