using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Color newColor;
    Color ogColor;
    Text thisTxt;
    // Start is called before the first frame update
    void Start()
    {
        thisTxt = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverStart() {

        ogColor = thisTxt.color;
        thisTxt.color = newColor;

    }

    public void HoverEnd() {
        thisTxt.color = ogColor;
    }
}
