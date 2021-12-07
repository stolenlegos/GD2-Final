using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

  private int sheep;
  [SerializeField] private Text sheepCounter;
  [SerializeField] private Text timer;
  [SerializeField] private GameObject winUI;
  [SerializeField] private GameObject loseUI;


    void Start() {
      sheep = 0;
      winUI.SetActive(false);
      loseUI.SetActive(false);
      SheepEvents.SheepCollected += IncreaseSheepCount;
      SheepEvents.SheepEscaped += DecreaseSheepCount;
      UIEvents.TimerUpdated += UpdateTimerCount;
      UIEvents.GameWon += Win;
      UIEvents.GameLost += Lose;
    }


    void Update() {
        UpdateSheepCount();
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
}
