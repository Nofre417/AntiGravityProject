using UnityEngine;

public class Absorber : MonoBehaviour
{
    [SerializeField] private Receiver.Receiver _receiver;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Box.Box box = other.gameObject.GetComponent<Box.Box>();
            
            _receiver.CompareEnteredBox(box);
            
            Destroy(other.gameObject);
        }
    }
}
