using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    
    public static GameManager Instance { get { Init(); return s_instance; } }
    void Start()
    {
        Init();
        //this.AddComponent<PlayerManager>();
        
    }
    
    void Update()
    {
        
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<PlayerManager>();
            }   
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<GameManager>();
        }
        Debug.Log("Process Success");
    }
}