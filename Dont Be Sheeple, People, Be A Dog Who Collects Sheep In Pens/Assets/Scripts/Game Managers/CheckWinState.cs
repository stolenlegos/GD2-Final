using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinState : MonoBehaviour {
  private List<GameObject> _sheepInLevel = new List<GameObject>();
  private int sheepSafe;


    void Start() {
      sheepSafe = 0;
      AddSheepToList();
      SheepEvents.SheepCollected += IncreaseSheepSafeCount;
      SheepEvents.SheepEscaped += DecreaseSheepSafeCount;
    }


    void Update() {
      if (sheepSafe >= _sheepInLevel.Count) {
        GameWon();
      }
      Debug.Log(_sheepInLevel.Count);
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


    private void AddSheepToList() {
      foreach (GameObject sheepObj in GameObject.FindGameObjectsWithTag("Sheep")) {
        _sheepInLevel.Add(sheepObj);
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
