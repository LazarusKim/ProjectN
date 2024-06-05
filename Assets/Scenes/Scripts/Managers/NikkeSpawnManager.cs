using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NikkeSpawnManager : MonoBehaviour
{
    [SerializeField] private Vector3[] spawnPos;
    public GameObject nikke;

    void Start()
    {
        if (nikke)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                Instantiate(nikke, spawnPos[i], Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}