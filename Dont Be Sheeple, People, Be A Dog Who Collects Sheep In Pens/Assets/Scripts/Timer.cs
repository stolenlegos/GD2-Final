using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
  private float floatTimer;
  private int intTimer;


    void Start () {
      floatTimer = 120f;
      intTimer = 120;
    }


    void Update () {
      floatTimer -= Time.deltaTime;
      intTimer = Mathf.RoundToInt(floatTimer);

      UIEvents.UpdateTimer(intTimer.ToString());
    }


    public void SetTimer (float num) {
      floatTimer = num;
      intTimer = Mathf.RoundToInt(floatTimer);
    }
}
