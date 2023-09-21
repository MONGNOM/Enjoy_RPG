using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public void OnQuit()
    {
        Application.Quit();
    }
}
