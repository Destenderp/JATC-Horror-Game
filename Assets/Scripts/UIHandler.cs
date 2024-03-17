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
    [SerializeField]TextMeshProUGUI ammoCounter;

    public void setInteractText(bool isActive, String interactName)
    {
        interactText.gameObject.SetActive(isActive);
        interactText.text = "Press E to Interact with " + interactName;
    }
    public void setInteractText(bool isActive)
    {
        interactText.gameObject.SetActive(isActive);
    }
    public void updateBullets(int ammoInGun, int ammoOnPlayer)
    {
        ammoCounter.text = ammoInGun + " / " + ammoOnPlayer;
    }
}
