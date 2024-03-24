using Box;
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

        [Header("Lose Statements")] 
        [SerializeField] private int _boxesToLose = 10;

        [Header("Lose Panel")]
        [SerializeField] private LosePanel _losePanel;

        [Header("Spawner")] 
        [SerializeField] private BoxSpawner _boxSpawner;
        
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

        public int WrongBoxes
        {
            get => _wrongBoxes;
            set
            {
                _wrongBoxes = value;

                if (_wrongBoxes >= _boxesToLose)
                {
                    LosePanel();
                }
            }
        }

        private void LosePanel()
        {
            _boxSpawner.ToSpawn = false;
            _losePanel.LoseValue = _wrongBoxes;
            _losePanel.SwitchPanel(true);
        }

        private int _score = 0;
        private int _boxAmount = 0;
        private int _wrongBoxes = 0;

        private void Start()
        {
            SetReceivers();
            
            BestScoreDataController.ResetValues();
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