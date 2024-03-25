using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private GameObject _soundController;
        
        [SerializeField] private TextMeshProUGUI _scoreValueText;
        [SerializeField] private TextMeshProUGUI _boxesValueText;

        private GameData _gameData;
        
        private string _recordsFilePath = "";
        private readonly string _recordsFileName = "RecordsData";

        private void Awake()
        {
            this._recordsFilePath = Path.Combine(Application.dataPath, this._recordsFileName);

            if (File.Exists(_recordsFilePath))
            {
                this._gameData = BestScoreLoader.LoadResults<GameData>(this._recordsFilePath);
            }
            
            DontDestroyOnLoad(_soundController);
        }

        private void Start()
        {
            if (BestScoreDataController.Score > _gameData.score)
            {
                _gameData.score = BestScoreDataController.Score;
            }

            if (BestScoreDataController.Boxes > _gameData.boxes)
            { 
                _gameData.boxes = BestScoreDataController.Boxes;
            }
            
            _scoreValueText.text = $"{_gameData.score}";
            _boxesValueText.text = $"{_gameData.boxes}";
        }
        
        public void LoadLevel()
        {
            SceneManager.LoadScene("Gameplay Scene");
        }

        public void BestScore()
        {
            //Open Best Score Panel
        }

        public void Settings()
        {
            //Open Setting Panel
        }
        

        public void Exit()
        {
            BestScoreLoader.SaveResults(this._recordsFilePath, this._gameData);
            Application.Quit();
        }

        private void OnApplicationQuit()
        {
            BestScoreLoader.SaveResults(this._recordsFilePath, this._gameData);
        }
    }
}