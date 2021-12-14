using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfBoundsCheck : MonoBehaviour
{
  private bool inBound = true;

    void OnTriggerExit(Collider other) {
      if (other.tag == "Boundary") {
        inBound = false;
        SheepEvents.CheckBounds(inBound);
        Debug.Log("OUT OF BOUNDS");
      }
    }

    void OnTriggerEnter (Collider other) {
      if (other.tag == "Boundary") {
        inBound = true;
        SheepEvents.CheckBounds(inBound);
      }
    }
}
