using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinState : MonoBehaviour {
  private int sheepGoal;
  private int sheepSafe;
  [SerializeField] private ProceduralSheep sheepGen;


    void Awake() {
      sheepSafe = 0;

      SheepEvents.SheepCollected += IncreaseSheepSafeCount;
      SheepEvents.SheepEscaped += DecreaseSheepSafeCount;
    }


    void Start() {
      if (sheepGen.sheepInLevel > 8) {
        SheepEvents.GoalSet(sheepGen.sheepInLevel - 4);
        sheepGoal = sheepGen.sheepInLevel - 4;
      } else if (sheepGen.sheepInLevel > 3 && sheepGen.sheepInLevel < 8) {
        SheepEvents.GoalSet(sheepGen.sheepInLevel - 2);
        sheepGoal = sheepGen.sheepInLevel - 2;
      } else {
          SheepEvents.GoalSet(sheepGen.sheepInLevel);
          sheepGoal = sheepGen.sheepInLevel;
      }
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
