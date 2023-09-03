using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attackinteraction : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite interactionImage;
    public Sprite attackImage;

    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeImage()
    { 
        image.sprite = interactionImage;
    }
    public void NotChangeImage()
    {
       image.sprite = attackImage;

    }

    
}   
