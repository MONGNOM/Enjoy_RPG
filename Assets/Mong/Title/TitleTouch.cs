using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleTouch : MonoBehaviour
{
    private void OnTouchScreen(InputValue value)
    {
        SceneManager.LoadScene("LoginScene");
    }
}
