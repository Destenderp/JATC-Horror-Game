using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    [SerializeField]int health;
    private float distance;

    private PlayerWeapon s_playerWeapon;
    [SerializeField]UIHandler s_UIHandler;
    private Rigidbody2D rb;

    [SerializeField]GameObject interactable;
    [SerializeField]GameObject flashLight;
    //[SerializeField]GameObject cam;

    LayerMask interactMask;

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

        interactMask = LayerMask.GetMask("Interactable");

        fb = flashBattery();

        rb = gameObject.GetComponent<Rigidbody2D>();
        s_playerWeapon = gameObject.GetComponentInChildren<PlayerWeapon>();
        s_UIHandler.updateBullets(s_playerWeapon.getcurrentMagSize(), ammoCount);
        updateFlashlight(checkFlashBattery());
        Debug.Log(flashLight);
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement();
        updateUI();
        updateFlashBattery();
    }
    //Updates the players rotation based on keyboard input and mouse input
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
    }
    //Toggles the Flashlight based on Player Input
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
    //Sets flashlight active state
    void updateFlashlight(bool state)
    {
        flashLight.SetActive(state);
    }
    //Checks battery state and returns a boolean
    bool checkFlashBattery()
    {
        if(battery <= 0)
            return false;
        else
            return true;
    }
    // 
    void updateFlashBattery()
    {
        if(batteryUpdate == false && flashLight.activeSelf == true)
        {
            Debug.LogAssertion("Killing Battery");
            StartCoroutine("flashBattery");
        }
        if(!checkFlashBattery())
        {
            updateFlashlight(false);
            StopCoroutine("flashBattery");
            batteryUpdate = false;
        }
        s_UIHandler.updateBattery(battery);
    }
    // Threads killing the battery every 3 seconds
    IEnumerator flashBattery()
    {
        //Debug.LogError("Killing Battery");
        batteryUpdate = true;
        yield return new WaitForSeconds(3);
        battery--;
        batteryUpdate = false;
    }
    //Fires the players weapon based on input from the Input System
    void shoot(InputAction.CallbackContext ctx)
    {
        s_playerWeapon.shoot();
        s_UIHandler.updateBullets(s_playerWeapon.getcurrentMagSize(), ammoCount);
    }
    //Reloads the gun if there is ammo avaliable
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
    //Fires a raycast and checks if there is something the player can interact with
    void interact(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 2,  interactMask);
        if(hit == true)
        {
            Intractable temp = hit.transform.gameObject.GetComponent<Intractable>();
            ammoCount += temp.getBulletCount();
            battery += temp.getBatteryCount();
            health += temp.getHealthCount();
            battery = Mathf.Clamp(battery, 0, 100);
            health = Mathf.Clamp(health, 0, 100);
            temp.useInteractable();
        }
        s_UIHandler.updateBullets(s_playerWeapon.getcurrentMagSize(), ammoCount);
        s_UIHandler.updateBattery(battery);
        s_UIHandler.updateHealth(health);
    }
    //Updates the UI if there something new to update
    void updateUI()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 2,  interactMask);
        if(hit == true)
            s_UIHandler.setInteractText(true, hit.transform.gameObject);
        else
            s_UIHandler.setInteractText(false);
    }
    //Retuns the distance the mouse is from the player
    public float getDistance()
    {
        return distance;
    }
    void checkHealth()
    {
        if(health == 0)
            SceneManager.LoadScene(1);
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        s_UIHandler.updateHealth(health);
        checkHealth();
    }
}
