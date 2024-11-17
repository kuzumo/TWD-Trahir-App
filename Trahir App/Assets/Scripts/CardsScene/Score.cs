using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
private TMP_Text score;
private int roundAmount;
// start is called before the first frame update
    void Start()
    {
    roundAmount = 1;
    score = GetComponent<TMP_Text>();
    }

    private void Update()
    {
    score. text = roundAmount.ToString();
    }

    public void AddScore()
    {
    roundAmount += 1;
    }
}