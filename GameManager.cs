using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cameraControls;

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SetCameraControls()
    {
        if(cameraControls.activeSelf)
        {
            cameraControls.SetActive(false);
        }
        else
        {
            cameraControls.SetActive(true);
        }
    }
}
