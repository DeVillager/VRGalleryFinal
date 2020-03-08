﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject bullet;
    public Transform barrelPivot;
    public float shootingSpeed = 1;
    public GameObject muzzleFlash;

    private Animator animator;
    private Interactable interactable;

    void Start()
    {
        //animator = GetComponent<Animator>();
        //muzzleFlash.SetActive(true);
        interactable = GetComponent<Interactable>();
    }

    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (fireAction[source].stateDown)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        Debug.Log("Fire");
        //Rigidbody bulletRB = Instantiate(bullet, barrelPivot.position, barrelPivot.rotation).GetComponent<Rigidbody>();
        Bullet bulletSc = Instantiate(bullet, barrelPivot.position, barrelPivot.rotation).GetComponent<Bullet>();
        //bulletRB.velocity = barrelPivot.forward * shootingSpeed;
        bulletSc.SetSpeed(shootingSpeed);
        //bulletRB.AddForce(barrelPivot.forward * shootingSpeed);
        //muzzleFlash.SetActive(true);
    }
}