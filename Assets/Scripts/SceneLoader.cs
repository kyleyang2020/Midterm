using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName; // name of scene to change
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName); // change to scene named
    }
}
