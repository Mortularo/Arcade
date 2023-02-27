using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Gunship
{
    public class RestartController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _endScore;
        public ScoreManager _sm;

        private void Update()
        {
            _endScore.text = "score is: " + _sm._score.ToString();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}