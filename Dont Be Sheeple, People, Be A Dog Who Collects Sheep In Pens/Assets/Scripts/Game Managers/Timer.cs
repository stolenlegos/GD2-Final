using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
  [SerializeField] private float floatTimer;
  private int intTimer;


    void Start () {
      intTimer = Mathf.RoundToInt(floatTimer);
    }


    void Update () {
      floatTimer -= Time.deltaTime;
      intTimer = Mathf.RoundToInt(floatTimer);

      UIEvents.UpdateTimer(intTimer.ToString());

      if (floatTimer <= 0) {
        UIEvents.LoseTime();
      }
    }


    public void SetTimer (float num) {
      floatTimer = num;
      intTimer = Mathf.RoundToInt(floatTimer);
    }
}
