using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFailState : MonoBehaviour {
  private int sheepDied;
  private int maxSheepDied;
  private List<GameObject> _sheepInLevel = new List<GameObject>();


    void Awake() {
      SheepEvents.SetGoal += SetGoal;
      foreach (GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep")) {
        _sheepInLevel.Add(sheep);
      }
    }


    void Start() {
      sheepDied = 0;
      SheepEvents.SheepDied += UpdateSheepDied;
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
      Debug.Log("Max Sheep Can Die: " + maxSheepDied.ToString());
    }


    void OnDestroy() {
      SheepEvents.SheepDied -= UpdateSheepDied;
    }
}
