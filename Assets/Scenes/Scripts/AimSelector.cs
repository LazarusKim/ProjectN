using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimSelector : MonoBehaviour
{
    [SerializeField] private Sprite[] crosshairs;
    private int numCrossHairs = 0;
    private Image crosshair;
    private RectTransform crosshairRectTransform;
    private AimController _aimController;
    void Start()
    {
        crosshair = GetComponentInParent<Image>();
        crosshairRectTransform = GetComponentInParent<RectTransform>();
        _aimController = crosshair.GetComponentInParent<AimController>();
        //crosshair.sprite = crosshairs[numCrossHairs];
    }

    
    void Update()
    {
        // Test code
        // When the click nikke illust, crosshair gonna change
        // Set default transform when sprite changed
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (numCrossHairs < crosshairs.Length -1)
            {
                numCrossHairs++;

            }
            else
            {
                numCrossHairs = 0;
            }

            crosshairRectTransform.anchoredPosition = Vector2.zero;
            crosshair.sprite = crosshairs[numCrossHairs];
            _aimController.isOnDrag = false;
        }
    }
}
