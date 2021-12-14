using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFailState : MonoBehaviour {
  private int sheepDied;
  private int maxSheepDied;
  private List<GameObject> _sheepInLevel = new List<GameObject>();


    void Awake() {
      sheepDied = 0;

      SheepEvents.SetGoal += SetGoal;
      SheepEvents.SheepDied += UpdateSheepDied;

      foreach (GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep")) {
        _sheepInLevel.Add(sheep);
      }
    }


    void Update() {
      if (sheepDied > maxSheepDied) {
        GameFailed();
      }
    }

    private void UpdateSheepDied(GameObject obj) {
      if (obj.tag == "Sheep") {
        sheepDied += 1;
      }
    }


    private void GameFailed() {
      UIEvents.LoseGame();
    }


    private void ResetDeaths () {
      sheepDied = 0;
    }


    private void SetGoal(int num) {
      maxSheepDied = _sheepInLevel.Count - num;
      //Debug.Log("Max Sheep Can Die: " + maxSheepDied.ToString());
    }


    void OnDestroy() {
      SheepEvents.SetGoal -= SetGoal;
      SheepEvents.SheepDied -= UpdateSheepDied;
    }
}
