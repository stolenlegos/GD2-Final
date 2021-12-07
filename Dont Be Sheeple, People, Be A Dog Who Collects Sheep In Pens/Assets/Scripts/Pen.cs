using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour {

  void OnTriggerEnter (Collider other) {
    if (other.tag == "Sheep") {
      SheepEvents.CollectSheep(other.gameObject);
    }
  }


  void OnTriggerExit (Collider other) {
    if (other.tag == "Sheep") {
      SheepEvents.EscapeSheep(other.gameObject);
    }
  }
}
