using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

  private int sheep;
  [SerializeField]
  private Text sheepCounter;
  [SerializeField]
  private Text timer;


    void Start() {
      sheep = 0;
      SheepEvents.SheepCollected += IncreaseSheepCount;
      UIEvents.TimerUpdated += UpdateTimerCount;
    }


    void Update() {
        UpdateSheepCount();
    }

    private void UpdateSheepCount() {
      sheepCounter.text = "Sheep Collected: " + sheep.ToString();
    }


    private void UpdateTimerCount(string timeLeft) {
      timer.text = "Time Left: " + timeLeft;
    }


    private void IncreaseSheepCount(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheep += 1;
      }
    }
}
