using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class BirdSelector : MonoBehaviour
{
    SpriteRenderer img;
    Button button;
    Color setColor;
    // Start is called before the first frame update
    void Start()
    {
        img.color = Color.white;

        if (ColorUtility.TryParseHtmlString("#FF5733", out setColor)) {
            //button.image.getColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
