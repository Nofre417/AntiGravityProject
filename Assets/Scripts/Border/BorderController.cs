using System;
using UnityEngine;

namespace Border
{
    public class BorderController : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Box"))
            {
                other.gameObject.layer = 10;
            }
        }
    }
}