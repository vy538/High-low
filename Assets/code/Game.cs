using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public bool startGame = false;

    public Dictionary<string, float> entries = new Dictionary<string, float>();
    public bool readTheData = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!readTheData)
        {
            Debug.Log("not read");
        }
        else {
            if (!startGame)
            {
                //Debug.Log("game not start yet");
            }
            else {
                GameRunning();
            }
        }
        
    }

    void GameRunning() {

    }

    public void StartTheGame() {
        startGame = false;
    }
}
