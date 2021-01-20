using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Canvas attributes
    public GameObject startCanvas;
    public GameObject playCanvas;
    public GameObject finishCanvas;

    //count of score
    public TextMeshProUGUI countOfMoney;
    private float money;

    //wich place take player
    public TextMeshProUGUI placeOfPlayer;
   

    public static GameController gamecontroller;
    // Start is called before the first frame update
    void Start()
    {
        gamecontroller = this;
        Time.timeScale = 0;
        playCanvas.SetActive(false);
        finishCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickPlay()
    {
       startCanvas.SetActive(false);
        StartCoroutine(StartGame());
    }
    public void OnRestartGame()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    IEnumerator StartGame()
    {
        playCanvas.SetActive(true);
        Time.timeScale = 1;

       yield return new WaitForSeconds(1.5f);
    }

    public void AddScore()
    {
        money++;
        countOfMoney.text ="Your score: "+ money.ToString();
    }

    public void GetFinish()
    { 
        playCanvas.SetActive(false);
        StartCoroutine(FinishGame());
    }

    IEnumerator FinishGame()
    {
         Time.timeScale = 0;
       
        finishCanvas.SetActive(true);
       // placeOfPlayer.text = "Your are in : " + place.ToString() + " PLACE";
        yield return new WaitForSeconds(0.5f);
    }
    public void PlayerPlace(int numberOfPlace)
    {
        placeOfPlayer.text = "Your are in : " + numberOfPlace.ToString() + " PLACE";
    }
   
}


