using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gunship
{
    public class WinMenu : MonoBehaviour
    {
        public static bool IsPaused = false;
        [SerializeField] private TextMeshProUGUI _endScore;
        public ScoreManager _sm;
        private void Update()
        {
            _endScore.text = "score is: " + _sm._score.ToString();
        }
        public void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}