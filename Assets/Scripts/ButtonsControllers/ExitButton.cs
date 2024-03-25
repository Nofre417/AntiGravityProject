using LevelControllers;
using UnityEngine;

namespace ButtonsControllers
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        
        public void SetButtonStatus()
        {
            _levelController.PlayClickSound();
           _levelController.LevelExit();
        }
    }
}