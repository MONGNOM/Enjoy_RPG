using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleTouch : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;

    [SerializeField]
    private GameObject textBlink;

    [SerializeField]
    private GameObject touchPanel;

    [SerializeField]
    private GameObject loginPanel;

    private void OnTouchScreen(InputValue value)
    {
        titleText.gameObject.SetActive(false);
        textBlink.SetActive(false);
        touchPanel.SetActive(false);
        LoadingController.LoadScene("MGameScene");
        //loginPanel.SetActive(true);
    }
}
