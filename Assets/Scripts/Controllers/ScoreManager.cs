
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gunship
{
    public class ScoreManager : MonoBehaviour
    {
        public int _score;
        [SerializeField] private TextMeshProUGUI _display;
        void Update()
        {
            _display.text = _score.ToString();
        }
        public void ScoreUp()
        {
            _score ++;
        }
    }
}