using UnityEngine;

namespace Box
{
    public class Box : MonoBehaviour
    {
        public int Id => _id;
        
        private int _id;
        private Rigidbody _rb;
        private MeshRenderer _meshRenderer;
        
        public void Initialisation(int id, int mass, Material material)
        {
            _rb = this.gameObject.GetComponent<Rigidbody>();
            _meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

            this._id = id;
            this._rb.mass = mass;
            this._meshRenderer.material = material;
        }
    }
}