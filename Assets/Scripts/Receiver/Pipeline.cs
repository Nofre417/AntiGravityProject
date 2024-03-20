using System;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    [SerializeField] private float _pipeLineSpeed = 2f;
    
    private List<GameObject> _boxList;

    private void Start()
    {
        _boxList = new();
    }

    private void FixedUpdate()
    {
        MoveBox();
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            GameObject box = other.gameObject;
            
            _boxList.Add(box);

            if (box != null)
            {
                Rigidbody rb = box.GetComponent<Rigidbody>();

                rb.rotation = Quaternion.Euler(0f, 0f, 0f);
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.useGravity = true;
            }
        }
    }
    
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            GameObject box = other.gameObject;
            
            _boxList.Add(box);

            if (box != null)
            {
                Rigidbody rb = box.GetComponent<Rigidbody>();

                rb.useGravity = true;
                rb.mass = rb.mass * 100000;
                rb.velocity = new Vector3(0f, 0f, 0f);
            }
        }
    }
    */

    private void MoveBox()
    {
        if (_boxList != null && _boxList.Count >= 1)
        {
            foreach (var box in _boxList)
            {
                if (box != null)
                {
                    Vector3 currentPosition = box.transform.position;

                    float newXPosition = currentPosition.x + (_pipeLineSpeed / 10000 * Time.fixedTime);

                    box.transform.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);
                }
            }
        }
    }
}
