﻿using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DuplicateManager : MonoBehaviour
{
    //private Interactable interactable;

    //void Start()
    //{
    //    interactable = GetComponent<Interactable>();
    //}
    public static DuplicateManager instance;
    public SteamVR_Action_Boolean TriggerClick;
    public Transform container;
    public GameObject sphere;
    public int childLimit = 60;

    private SteamVR_Input_Sources inputSource;
    private bool handHover = false;
    private GameObject activeObject;

    private void OnEnable()
    {
        instance = this;
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    public void OnHandHoverBegin()
    {
        handHover = true;
    }

    public void OnHandHoverEnd()
    {
        handHover = false;
    }



    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (handHover)
        {
            print("Success");
            RemoveDuplicates();
        }
    }


    void RemoveDuplicates()
    {
        Debug.Log("Duplicates destroyed");
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
        GetComponent<AudioSource>().Play();
        sphere.transform.position = transform.position + Vector3.up * 0.2f;
        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
        container.GetComponent<BlobInitializer>().MakeSceneBlobs();
    }

    public void SetActiveObject(GameObject go)
    {
        activeObject = go;
    }

    private void Update()
    {
        int blobsAmount = container.childCount;
        if (blobsAmount > childLimit)
        {
            int removeAmount = blobsAmount - childLimit;
            for (int i = 0; i < removeAmount; i++)
            {
                GameObject destroyable = container.GetChild(i).gameObject;
                if (destroyable != activeObject)
                {
                    Destroy(destroyable);
                }
            }
        }
    }
}
