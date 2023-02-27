using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gunship
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool IsPaused = false;
        [SerializeField] private GameObject _pauseMenu;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    Resume();
                }
                else
                {
                    PauseOn();
                }
            }
        }
        #region Methods 
        public void Resume()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
        public void PauseOn()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
        public void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            IsPaused = false;
        }
        public void QuitGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            IsPaused = false;
        }
        #endregion
    }
}