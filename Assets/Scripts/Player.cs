using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class Player : MonoBehaviour
{
    IEnumerator fb;

    [SerializeField]InputAction c_playerMove;
    public InputAction c_mousePosition;
    [SerializeField]InputAction c_shoot;
    [SerializeField]InputAction c_reload;
    [SerializeField]InputAction c_interact;
    [SerializeField]InputAction c_flashLight;
    
    [SerializeField]float speed;
    [SerializeField]int ammoCount;
    [SerializeField]int battery;
    private float distance;

    private PlayerWeapon s_playerWeapon;
    [SerializeField]UIHandler s_UIHandler;
    private Rigidbody2D rb;

    [SerializeField]GameObject interactable;
    [SerializeField]GameObject flashLight;
    //[SerializeField]GameObject cam;

    LayerMask mask;

    bool batteryUpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        c_playerMove.Enable();
        c_mousePosition.Enable();
        c_shoot.Enable();
        c_reload.Enable();
        c_interact.Enable();
        c_flashLight.Enable();

        c_shoot.performed += shoot;
        c_reload.performed += reload;
        c_interact.performed += interact;
        c_flashLight.performed += toggleFlashlight;

        mask = LayerMask.GetMask("Interactable");

        fb = flashBattery();

        rb = gameObject.GetComponent<Rigidbody2D>();
        s_playerWeapon = gameObject.GetComponentInChildren<PlayerWeapon>();
        s_UIHandler.updateBullets(s_playerWeapon.getcurrentMagSize(), ammoCount);
        updateFlashlight(checkFlashBattery());
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement();
        updateUI();
        updateFlashBattery();
    }
    void playerMovement()
    {
        Vector2 player, mouse;
        float angle;
        player = gameObject.transform.position;
        mouse = (Vector2)Camera.main.ScreenToWorldPoint(c_mousePosition.ReadValue<Vector2>());
        angle = Mathf.Atan2(player.y - mouse.y, player.x-mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle+90));
        distance = MathF.Sqrt(MathF.Pow(player.x-mouse.x,2)+MathF.Pow(player.y-mouse.y,2));

        rb.MovePosition(rb.position += c_playerMove.ReadValue<Vector2>()*Time.deltaTime*5);

        //cam.transform.position = new Vector3(player.x, player.y, -10);
    }
    void toggleFlashlight(InputAction.CallbackContext ctx)
    {
        if(flashLight.activeSelf == true)
        {
            updateFlashlight(false);
            batteryUpdate = false;
            StopCoroutine("flashBattery");
        }
        else if(flashLight.activeSelf == false && checkFlashBattery())
        {
            updateFlashlight(true);
        }
    }
    void updateFlashlight(bool state)
    {
        flashLight.SetActive(state);
    }
    bool checkFlashBattery()
    {
        if(battery <= 0)
            return false;
        else
            return true;
    }
    void updateFlashBattery()
    {
        Debug.Log(batteryUpdate);
        if(batteryUpdate == false && flashLight.activeSelf == true)
        {
            //Debug.LogWarning("Killing Battery");
            StartCoroutine("flashBattery");
        }
        if(!checkFlashBattery())
            updateFlashlight(false);
        s_UIHandler.updateBattery(battery);
    }
    IEnumerator flashBattery()
    {
        //Debug.LogError("Killing Battery");
        batteryUpdate = true;
        yield return new WaitForSeconds(3);
        battery--;
        batteryUpdate = false;
    }


    void shoot(InputAction.CallbackContext ctx)
    {
        s_playerWeapon.shoot();
        s_UIHandler.updateBullets(s_playerWeapon.getcurrentMagSize(), ammoCount);
    }
    void reload(InputAction.CallbackContext ctx)
    {
        int current = s_playerWeapon.getcurrentMagSize();
        int max = s_playerWeapon.getMaxMagSize();
        int need = max - current;
        if(need > ammoCount)
            need = ammoCount;
        if(ammoCount == 0)
        {
            Debug.Log("You are out of bullets");
            return;
        }
        Debug.Log(need);
        s_playerWeapon.reload(need);
        ammoCount -= need;
        s_UIHandler.updateBullets(s_playerWeapon.getcurrentMagSize(), ammoCount);
    }
    void interact(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 2,  mask);
        if(hit == true)
        {
            Intractable temp = hit.transform.gameObject.GetComponent<Intractable>();
            ammoCount += temp.getBulletCount();
            battery += temp.getBatteryCount();
            battery = Mathf.Clamp(battery, 0, 100);
            temp.useInteractable();
        }
        s_UIHandler.updateBullets(s_playerWeapon.getcurrentMagSize(), ammoCount);
        s_UIHandler.updateBattery(battery);
    }
    void updateUI()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 2,  mask);
        if(hit == true)
            s_UIHandler.setInteractText(true, hit.transform.gameObject);
        else
            s_UIHandler.setInteractText(false);
    }
    public float getDistance()
    {
        return distance;
    }
}
