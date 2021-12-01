using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinState : MonoBehaviour {
  private List<GameObject> _sheepInLevel = new List<GameObject>();
  private int sheepSafe;


    void Start() {
      sheepSafe = 0;
      AddSheepToList();
      SheepEvents.SheepCollected += UpdateSheepSafeCount;
    }


    void Update() {
      if (sheepSafe >= _sheepInLevel.Count) {
        GameWon();
      }
    }


    private void UpdateSheepSafeCount(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheepSafe += 1;
      }
    }


    private void AddSheepToList() {
      foreach (GameObject sheepObj in GameObject.FindGameObjectsWithTag("Sheep")) {
        _sheepInLevel.Add(sheepObj);
      }
    }


    private void GameWon() {
      Debug.Log("Congrats for winning the Game.");
    }
}
