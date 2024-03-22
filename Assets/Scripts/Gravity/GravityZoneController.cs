using System;
using System.Collections.Generic;
using Border;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gravity
{
    public class GravityZoneController : MonoBehaviour
    {
        [SerializeField] private float _gravityScale;
        [SerializeField] private bool _IsGravity = true;
        [SerializeField] private GateController gateController;

        public bool IsGravity
        {
            get => _IsGravity;
            set
            {
                _IsGravity = value;
                MoveBox();
            }
        }

        private List<GameObject> _boxList;

        private void Start()
        {
            _boxList = new();
        }
        

        public void SetGravity()
        {
            if (_IsGravity)
            {
                if (!gateController.IsOpen)
                {
                    _IsGravity = false;
                    gateController.IsOpen = true;
                }
            }
            else
            {
                _IsGravity = true;
            }
            
            MoveBox();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Box"))
            {
                _boxList.Add(other.gameObject);

                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

                if (rb != null && !_IsGravity)
                {
                    rb.useGravity = false;
                    MoveBox();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Box"))
            {
                GameObject box = other.gameObject;

                if (box != null)
                {
                    Rigidbody rb = box.GetComponent<Rigidbody>();

                    rb.velocity = new Vector3(0f, 0f, 0f);
                    rb.useGravity = true;
                    
                    if (_boxList != null && _boxList.Contains(box))
                    {
                        _boxList.Remove(box);
                    }
                }
            }
        }
        
        private void MoveBox()
        {
            if (_boxList != null && _boxList.Count >= 1)
            {
                foreach (var box in _boxList)
                {
                    if (box != null)
                    {
                        Rigidbody rb = box.GetComponent<Rigidbody>();
                        
                        if (rb != null)
                        {
                            Vector3 gravity;
                            
                            if (_IsGravity)
                            {
                                rb.useGravity = true;
                            }
                            else if(_IsGravity == false && rb.useGravity)
                            {
                                rb.useGravity = false;
                                gravity = new Vector3(0, (_gravityScale - 0.5f), 0);
                                
                                rb.AddForce(gravity, ForceMode.Acceleration);
                            }
                        }
                    }
                }
            }
        }
    }
}