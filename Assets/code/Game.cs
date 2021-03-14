using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public bool startGame = false;

    public Dictionary<string, float> entries = new Dictionary<string, float>();
    public bool readTheData = false;
    public GameObject BG;
    public GameObject Card;
    public Text opt1Text;
    public Text opt2Text;
    public Text Question;

    Animator CardAni;
    int numberQuestion = 0;
    string randomKey1, randomKey2;
    string outComeStrin1, outComeStrin2;
    List<string> keyList;
    int correctAns = -1;
    bool hasQuestion = false;

    // Start is called before the first frame update
    void Start()
    {
        CardAni = Card.GetComponent<Animator>();   
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
        if (!hasQuestion)
        {
            QuestionSelection();
        }
    }

    void QuestionSelection() {
        StopAllCoroutines();
        numberQuestion += 1;
        System.Random rand = new System.Random();
        randomKey1 = keyList[rand.Next(keyList.Count)];
        do
        {
            randomKey2 = keyList[rand.Next(keyList.Count)];
        } while (randomKey2 == randomKey1);

        Question.text = "Q" + numberQuestion + ": Which is higher?";
        opt1Text.text = "➡️"+randomKey1;
        opt2Text.text = "➡️" + randomKey2;

        if (entries[randomKey1] > entries[randomKey2])
        {
            correctAns = 1;
            outComeStrin1 = "➡️" + randomKey1 + " => " + entries[randomKey1];
            outComeStrin2 = "➡️" + randomKey2 + " => " + entries[randomKey2];
        }
        else {
            correctAns = 2;
            outComeStrin1 = "➡️" + randomKey1 + " => " + entries[randomKey1];
            outComeStrin2 = "➡️" + randomKey2 + " => " + entries[randomKey2];
        }

        hasQuestion = true;
        Card.SetActive(true);
    }


    public void getBtn(int btnNum) {
        if (btnNum == correctAns)
        {
            StartCoroutine(hideCard());
        }
        else {
            StartCoroutine(ending());
        }
    }

    IEnumerator ending() {
        Card.GetComponent<Animator>().SetTrigger("wrong");
        Question.text = "☠️Wrong☠️";
        if (correctAns == 1)
        {
            outComeStrin1 += " ✔️";
            outComeStrin2 += " ☠️";
        }
        else {
            outComeStrin2 += " ✔️";
            outComeStrin1 += " ☠️";
        }
        opt1Text.text = outComeStrin1;
        opt2Text.text = outComeStrin2;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    IEnumerator hideCard() {
        Card.GetComponent<Animator>().SetTrigger("correct");
        Question.text = "Correct✔️✔️✔️";
        if (correctAns == 1)
        {
            outComeStrin1 += " ✔️";
        }
        else
        {
            outComeStrin2 += " ✔️";
        }
        opt1Text.text = outComeStrin1;
        opt2Text.text = outComeStrin2;
        yield return new WaitForSeconds(2f);
        Card.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(0.5f);
        Card.SetActive(false);
        hasQuestion = false;
    }

    public void StartTheGame() {
        keyList = new List<string>(entries.Keys);
        startGame = true;
        BG.SetActive(true);
        Card.SetActive(true);
    }
}
