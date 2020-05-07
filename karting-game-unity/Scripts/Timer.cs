using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timeCounter;
    static float timer; 
    public Text LastLapText;
    public GameObject RestartButton;

    void Start(){
        RestartButton.SetActive(false);
    }
   
    public void restartGame(){
        Debug.Log("restart");
        RestartButton.SetActive(false);
        SceneManager.LoadScene("KartingScene");
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timeCounter.text = niceTime;

        if(GameObject.Find("Kart").transform.position.y < 0){
            RestartButton.SetActive(true);
        }

        if(Input.GetKeyDown("joystick button 9")){
            restartGame();
        }
    }

    void OnTriggerExit(Collider other){
        LastLapText.text = "Last Lap: "+timeCounter.text;
        timer = 0.0f;
    }
}
