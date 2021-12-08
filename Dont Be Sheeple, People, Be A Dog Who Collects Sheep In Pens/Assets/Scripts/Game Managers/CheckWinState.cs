using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinState : MonoBehaviour {
  [SerializeField] private int sheepGoal;
  private int sheepSafe;


    void Awake() {
      sheepSafe = 0;
      
      SheepEvents.SheepCollected += IncreaseSheepSafeCount;
      SheepEvents.SheepEscaped += DecreaseSheepSafeCount;
    }


    void Start() {
      SheepEvents.GoalSet(sheepGoal);
    }


    void Update() {
      if (sheepSafe >= sheepGoal) {
        GameWon();
      }
    }


    private void IncreaseSheepSafeCount(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheepSafe += 1;
      }
    }


    private void DecreaseSheepSafeCount(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheepSafe -= 1;
      }
    }


    private void GameWon() {
      UIEvents.WinGame();
    }


    void OnDestroy() {
      SheepEvents.SheepCollected -= IncreaseSheepSafeCount;
      SheepEvents.SheepEscaped -= DecreaseSheepSafeCount;
    }
}
