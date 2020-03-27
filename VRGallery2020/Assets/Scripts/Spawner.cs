﻿using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPrefab;

    [SerializeField]
    private int size = 5;

    [SerializeField]
    private float spawnTime = 5f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-size, size), 0, Random.Range(-size, size));
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Instantiate(spawnPrefab, randomPosition, randomRotation);
            yield return new WaitForSeconds(spawnTime);
        }   
    }
}