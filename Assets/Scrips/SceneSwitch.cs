using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public class SceneChanger : MonoBehaviour
    {
        // You can call this method to change to a specific scene by name
        public void ChangeToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        // Example of usage in Unity's UI Button
        public void OnButtonClick(string sceneName)
        {
            ChangeToScene(sceneName);
        }
    }
}
