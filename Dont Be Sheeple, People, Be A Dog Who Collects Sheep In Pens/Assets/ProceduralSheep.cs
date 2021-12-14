using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralSheep : MonoBehaviour {
  [SerializeField] private GameObject sheep;
  private int xPos;
  private int zPos;
  private int sheepCount;
  public int sheepInLevel;

  void Awake () {
    sheepInLevel = Random.Range(1, 12);
  }

  void Start() {
    StartCoroutine(EnemyDrop());
  }

  IEnumerator EnemyDrop() {
    while (sheepCount < sheepInLevel) {
      xPos = Random.Range(333, 397);
      zPos = Random.Range(494, 562);
      Instantiate(sheep, new Vector3(xPos, 41f, zPos), Quaternion.identity);
      yield return new WaitForSeconds(0.0001f);
      sheepCount += 1;
    }
  }
}
