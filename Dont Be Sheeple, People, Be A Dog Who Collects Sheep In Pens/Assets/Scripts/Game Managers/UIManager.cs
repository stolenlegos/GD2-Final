using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

  private int sheep;
  [SerializeField] private Text sheepCounter;
  [SerializeField] private Text timer;
  [SerializeField] private Text loseText;
  [SerializeField] private GameObject winUI;
  [SerializeField] private GameObject loseUI;
  [SerializeField] private GameObject mainMenu;


    void Start() {
      Time.timeScale = 0;
      sheep = 0;
      UpdateSheepCount();

      winUI.SetActive(false);
      loseUI.SetActive(false);
      mainMenu.SetActive(true);
      timer.gameObject.SetActive(false);
      sheepCounter.gameObject.SetActive(false);

      SheepEvents.SheepCollected += IncreaseSheepCount;
      SheepEvents.SheepEscaped += DecreaseSheepCount;
      UIEvents.TimerUpdated += UpdateTimerCount;
      UIEvents.GameWon += Win;
      UIEvents.GameLost += Lose;
      UIEvents.GameStarted += GameStart;
      UIEvents.TimeLost += TimedOut;
    }


    private void UpdateSheepCount() {
      sheepCounter.text = "Sheep Collected: " + sheep.ToString();
      Debug.Log(sheep);
    }


    private void UpdateTimerCount(string timeLeft) {
      timer.text = "Time Left: " + timeLeft;
    }


    private void IncreaseSheepCount(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheep += 1;
      }

        UpdateSheepCount();
    }


    private void DecreaseSheepCount(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheep -= 1;
      }
    }


    private void Win() {
      Time.timeScale = 0;
      winUI.SetActive(true);
    }


    private void Lose() {
      Time.timeScale = 0;
      loseUI.SetActive(true);
    }


    private void GameStart() {
      Time.timeScale = 1;
      mainMenu.SetActive(false);
      timer.gameObject.SetActive(true);
      sheepCounter.gameObject.SetActive(true);
    }


    private void TimedOut() {
      Time.timeScale = 0;
      loseUI.SetActive(true);
      loseText.text = "Unfortunately the sheep didn't get corralled in time and the coyotes feasted tonight.";
    }


    void OnDestroy() {
      SheepEvents.SheepCollected -= IncreaseSheepCount;
      SheepEvents.SheepEscaped -= DecreaseSheepCount;
      UIEvents.TimerUpdated -= UpdateTimerCount;
      UIEvents.GameWon -= Win;
      UIEvents.GameLost -= Lose;
      UIEvents.GameStarted -= GameStart;
      UIEvents.TimeLost -= TimedOut;
    }
}
