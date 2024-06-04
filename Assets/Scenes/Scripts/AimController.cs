using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{   
    [SerializeField] private Image crosshair;
    
    public bool isOnDrag = false;

    private RectTransform _aimRectTransform;
    private Vector2 _initMousePos;
    private Vector2 _initAimPos;
    private Vector2 _currentMousePos;
    private Vector2 _mouseDelta;
    private Vector2 _initMousePosInCanvas;
    private Vector2 _currentMousePosInCanvas;

    void Start()
    {
        _aimRectTransform = crosshair.GetComponent<RectTransform>();
    }
    
    void Update()
    {
        Dragging();
    }
    
    void Dragging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isOnDrag = true;
            _initAimPos = _aimRectTransform.anchoredPosition;
            _initMousePos = Input.mousePosition;

            // 초기 마우스 위치를 캔버스 로컬 좌표로 변환
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_aimRectTransform.parent as RectTransform,
                _initMousePos, null, out _initMousePosInCanvas);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isOnDrag = false;
        }
        
        if (isOnDrag)
        {
            _currentMousePos = Input.mousePosition;
            _mouseDelta = _currentMousePos - _initMousePos;

            // 현재 마우스 위치를 캔버스 로컬 좌표로 변환
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_aimRectTransform.parent as RectTransform,
                _currentMousePos, null, out _currentMousePosInCanvas);

            // 초기 에임 위치에 마우스 이동 벡터를 더하여 새로운 에임 위치 계산
            _aimRectTransform.anchoredPosition = _initAimPos + (_currentMousePosInCanvas - _initMousePosInCanvas);
        }
    }
}