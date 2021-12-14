using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDeath : MonoBehaviour {
  void OnTriggerEnter (Collider other) {
    if (other.tag == "Player Death") {
      UIEvents.KillPlayer();
    }
  }
}
