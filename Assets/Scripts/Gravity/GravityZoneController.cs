using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gravity
{
    public class GravityZoneController : MonoBehaviour
    {
        [Range(0, 25)] [SerializeField] private float _gravityScale;
        [SerializeField] private bool _IsGravity = true;

        private List<GameObject> _boxList;

        private void Start()
        {
            _boxList = new();
        }

        public void SetGravity()
        {
            if (_IsGravity == true) _IsGravity = false;
            else _IsGravity = true;
            
            MoveBox();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Box"))
            {
                _boxList.Add(other.gameObject);

                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
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
                                /*
                                gravity = new Vector3(0, ((_gravityScale - 0.5f) * -1f) * 8 , 0);

                                rb.AddForce(gravity, ForceMode.Acceleration);

                                print($"Gravity: {gravity.y}");
                                */
                            }
                            else if(_IsGravity == false && rb.useGravity == true)
                            {
                                rb.useGravity = false;
                                gravity = new Vector3(0, (_gravityScale - 0.5f), 0);
                                
                                rb.AddForce(gravity, ForceMode.VelocityChange);
                            }
                        }
                    }
                }
            }
        }
    }
}