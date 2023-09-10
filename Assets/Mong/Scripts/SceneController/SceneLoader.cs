using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void Login()
    {
        LoadingController.LoadScene("GameScene");
    }
}
