using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CometCleanUP
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        [SerializeField] private int sceneToLoadInt;

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        public void LoadSceneINT()
        {
            SceneManager.LoadScene(sceneToLoadInt);
        }
    }
}
