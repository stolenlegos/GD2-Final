using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFailState : MonoBehaviour {
  private int sheepDied;


    void Start() {
      sheepDied = 0;
      SheepEvents.SheepDied += UpdateSheepDied;
    }


    void Update() {
      if (sheepDied >= 3) {
        GameFailed();
      }
    }

    private void UpdateSheepDied(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheepDied += 1;
      }
    }


    private void GameFailed() {
      Debug.Log("Sorry You failed the Game.");
    }


    private void ResetDeaths () {
      sheepDied = 0;
    }
}