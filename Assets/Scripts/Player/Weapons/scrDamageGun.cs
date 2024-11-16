using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange;

    private Transform playerCamera;
    private AudioSource audioSource;
    void Start()
    {
        playerCamera = Camera.main.transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            //if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            //{

            //} 
        }
        audioSource.Play();
    }
}
