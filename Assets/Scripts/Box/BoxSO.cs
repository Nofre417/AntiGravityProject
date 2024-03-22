using UnityEngine;

namespace Box
{
    [CreateAssetMenu(menuName = "Box", fileName = "Box")]
    public class BoxSO : ScriptableObject
    {
        public int id;
        public Material material;
    }
}