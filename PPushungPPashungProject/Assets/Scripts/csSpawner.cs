/*
 *  Spring 2021
 *  Unity 2D Game Project
 *  Written by SeungGeon Kim & DongKyu Kim
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    //public Vector3 spawnPoint;
    public int maxPlayerCount;

    public float timer;
    public float spawnDelay;

    void Start()
    {
        
    }
    
    void Update()
    {

        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;

        timer += Time.deltaTime;

        if (timer >= spawnDelay) 
        {

            if (playerCount < maxPlayerCount)
            {
                // Quaternion.identity -> ���� �˷��ִ°�, �����Ƿ� ������ �н�. ������ �ʿ�.
                //Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
                Instantiate(
                    playerPrefab, 
                    new Vector3(transform.position.x, transform.position.y, 0), 
                    Quaternion.identity);
                timer = 0;
            }

        }

    }

}
