using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gunship
{
    public class MainMenu : MonoBehaviour
    {
        #region Methods
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void EndGame()
        {
            Debug.Log("Game has ended");
            Application.Quit();
        }
        #endregion
    }
}