using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    
    public static Managers Instance { get { Init(); return s_instance; } }
    void Start()
    {
        Init();
        this.AddComponent<PlayerManager>();
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
            s_instance = go.GetComponent<Managers>();
        }
        Debug.Log("Process Success");
    }
}
