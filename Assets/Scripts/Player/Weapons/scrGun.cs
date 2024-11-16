using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class scrGun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float fireCoolDown;

    public bool automatic;

    float currentCooldown;

    void Start()
    {
        currentCooldown = fireCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (currentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                }
            }
        }

        currentCooldown -= Time.deltaTime;
    }
}
