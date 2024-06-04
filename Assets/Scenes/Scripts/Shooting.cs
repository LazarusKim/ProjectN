using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    private AimController _aimController;
    private RectTransform _aimTransform;
    private Image _aimImage;

    private Vector3 _screenPoint;
    public Vector3 shootingDir;

    [SerializeField] private GameObject _shootingPos;
    private LineRenderer _lineRenderer;

    [SerializeField] private float _shootingRange;
    void Start()
    {

        _aimTransform = gameObject.GetComponentInParent<RectTransform>();
        if (_aimTransform)
        {
            //_aimTransform = _aimController.GetComponentInParent<RectTransform>();
            //if(_aimTransform)
            Debug.Log(_aimTransform.position);
        }
        else
        {
            Debug.Log("NullException");
        }
        
        if (!_lineRenderer)
        {
            _lineRenderer = gameObject.AddComponent<LineRenderer>();
            InitLineRenderer();
        }
        

    }

    
    void Update()
    {
       ShootRayFromCrosshair();
    }

    void ShootRayFromCrosshair()
    {
        // crosshair의 canvas상 좌표에서 Camera.main.ray
        // 월드를 향해 Z축으로 Ray 쏘기
        // ray쏜 방향으로 캐릭터 총 발사
        
        Ray ray = Camera.main.ScreenPointToRay(_aimTransform.position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * _shootingRange, Color.red);
        
        _lineRenderer.SetPosition(0, _shootingPos.transform.position);
        
        if (Physics.Raycast(ray, out hit))
        {
            _lineRenderer.SetPosition(1, hit.point);
            shootingDir = ray.origin + ray.direction;
            
            if (hit.collider.CompareTag("Shootable"))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
        }
        else
        {
            _lineRenderer.SetPosition(1, shootingDir * _shootingRange);
        }
    }

    void InitLineRenderer()
    {
        //LineRenderer Setting
        _lineRenderer.startWidth = 0.01f;
        _lineRenderer.endWidth = 0.01f;
        _lineRenderer.positionCount = 2;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.startColor = Color.yellow;
        _lineRenderer.endColor = Color.yellow;
    }
}
