using UnityEngine;

namespace Box
{
    public class BoxMovementController : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        
        private Rigidbody _rb;
        private Ray _ray;
        private RaycastHit _hit;
        private Camera _mainCamera;
        private Vector3 _impulse;
        
        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Input.GetMouseButtonDown(0))
            {
                MoveBox(clickMode: ClickMode.Left);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                MoveBox(clickMode: ClickMode.Right);
            }
        }

        private void MoveBox(ClickMode clickMode)
        {
            if (Physics.Raycast(_ray, out _hit, 100,_layerMask))
            {
                if (_hit.collider != null && _hit.collider.gameObject.CompareTag("Box"))
                {
                    _rb = _hit.collider.gameObject.GetComponent<Rigidbody>();

                    if (clickMode == ClickMode.Left)
                    {
                        _impulse = new Vector3(-5f,0f, 0f);
                    }
                    else if (clickMode == ClickMode.Right)
                    {
                        _impulse = new Vector3(5f,0f, 0f);
                    }
                    
                    _rb.AddForce(_impulse, ForceMode.Impulse);
                }
            }
        }
    }
}

public enum ClickMode
{
    Left = 0,
    Right = 1
}