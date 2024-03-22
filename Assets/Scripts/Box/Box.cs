using UnityEngine;

namespace Box
{
    public class Box : MonoBehaviour
    {
        public int Id => _id;
        
        private int _id;
        private MeshRenderer _meshRenderer;
        
        public void Initialisation(int id, Material material)
        {
            _meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

            this._id = id;
            this._meshRenderer.material = material;
        }
    }
}