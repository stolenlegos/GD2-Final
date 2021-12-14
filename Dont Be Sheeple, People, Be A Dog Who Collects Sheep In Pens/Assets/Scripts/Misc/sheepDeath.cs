using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepDeath : MonoBehaviour
{
  void OnTriggerEnter (Collider other) {
    if (other.tag == "Sheep") {
      SheepEvents.KillSheep(other.gameObject);
    }
  }
}
