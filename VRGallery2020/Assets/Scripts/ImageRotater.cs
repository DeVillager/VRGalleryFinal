﻿/* SceneHandler.cs*/
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;
using System;

public class ImageRotater : MonoBehaviour
{
    public GameObject Title;
    public GameObject Description;

    public void OnActivate()
    {
        gameObject.transform.Rotate(new Vector3(0, 90, 0), Space.World);
        Title.SetActive(false);
        Description.SetActive(true);
    }

    public void OnDeActivate()
    {
        gameObject.transform.Rotate(new Vector3(0, -90, 0), Space.World);
        Title.SetActive(true);
        Description.SetActive(false);
    }
}