using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimSelector : MonoBehaviour
{
    private string[] weaponTypesKeys;
    [SerializeField] private Sprite[] crosshairsValues;
    private Dictionary<string, Sprite> crossHairs;
    
    private Image crosshair;
    private RectTransform crosshairRectTransform;
    private AimController _aimController;

    private enum WeaponType
    {
        AR,
        SMG,
        SG,
        SR,
        RL,
        MG
    }

    private void InitWeaponMap()
    {
        crossHairs = new Dictionary<string, Sprite>();
        weaponTypesKeys = Enum.GetNames(typeof(WeaponType));   
        
        for(int i = 0; i < crosshairsValues.Length; i++)
        {
            crossHairs.Add(weaponTypesKeys[i], crosshairsValues[i]);
            Debug.Log(weaponTypesKeys[i]);
        }
    }
    void Awake()
    {
        InitWeaponMap();
    }

    

    void Start()
    {
        crosshair = GetComponentInParent<Image>();
        crosshairRectTransform = GetComponentInParent<RectTransform>();
        _aimController = crosshair.GetComponentInParent<AimController>();
    }

    
    void Update()
    {
        // Test code
        // When the click nikke illust, crosshair gonna change
        // Set default transform when sprite changed
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     if (numCrossHairs < crosshairs.Length -1)
        //     {
        //         numCrossHairs++;
        //
        //     }
        //     else
        //     {
        //         numCrossHairs = 0;
        //     }
        //
        //     crosshairRectTransform.anchoredPosition = Vector2.zero;
        //     crosshair.sprite = crosshairs[numCrossHairs];
        //     _aimController.isOnDrag = false;
        // }
    }
}
