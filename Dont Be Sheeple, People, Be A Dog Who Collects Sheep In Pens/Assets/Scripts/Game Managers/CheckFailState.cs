using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFailState : MonoBehaviour {
  private int sheepDied;
  private int maxSheepDied;
  private List<GameObject> _sheepInLevel = new List<GameObject>();
  private bool sheepInPosition;
  private int goal;


    void Awake() {
      sheepDied = 0;
      sheepInPosition = false;

      SheepEvents.SetGoal += SetGoal;
      SheepEvents.SheepDied += UpdateSheepDied;
    }

    void Start() {
      StartCoroutine(WaitForSheep());
    }


    void Update() {
      if (sheepDied > maxSheepDied && sheepInPosition) {
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
      Debug.Log("Shit is going to early");
    }


    private void ResetDeaths () {
      sheepDied = 0;
    }


    private void SetGoal(int num) {
      goal = num;
      //Debug.Log("Max Sheep Can Die: " + maxSheepDied.ToString());
    }

    private IEnumerator WaitForSheep() {
      yield return new WaitForSeconds(3);

      foreach (GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep")) {
        _sheepInLevel.Add(sheep);
      }

      maxSheepDied = _sheepInLevel.Count - goal;

      sheepInPosition = true;
    }


    void OnDestroy() {
      SheepEvents.SetGoal -= SetGoal;
      SheepEvents.SheepDied -= UpdateSheepDied;
    }
}
