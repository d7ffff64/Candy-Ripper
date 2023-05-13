using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CandyRipper.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadTitleMenu()
        {
            LoadScene(0);
        }
        public void LoadMainMenu()
        {
            LoadScene(1);
        }
        public void LoadMapSelect()
        {
            LoadScene(2);
        }
        public void LoadPlayerSelect()
        {
            LoadScene(3);
        }
        public void LoadLevel0()
        {
            LoadScene(4);
        }
        private void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
