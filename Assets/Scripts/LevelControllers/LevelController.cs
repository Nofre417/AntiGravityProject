using LevelControllers.View;
using MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelControllers
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ReceiversController _receiversController;
        [SerializeField] private LevelStatsView _levelStatsView;
        
        
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                _levelStatsView.Score = $"Score: {_score}";

                BestScoreDataController.SetMaxScore(_score);
            }
            
        }
        public int BoxAmount
        {
            get => _boxAmount;
            set
            {
                _boxAmount = value;
                _levelStatsView.BoxesAmount = $"Box: {_boxAmount}";

                BestScoreDataController.SetMaxBoxes(_boxAmount);
            }
        }
        
        private int _score = 0;
        private int _boxAmount = 0;

        private void Start()
        {
            SetReceivers();
            
            BestScoreDataController.ResetValues();
        }

        private void Update()
        {
            
        }

        private void SetReceivers()
        {
            if (_receiversController != null)
            {
                _receiversController.SetReceiversTargets();
            }
        }

        public void LevelRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LevelExit()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}