using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParametersScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int healValue = 1000;
    public TextMeshProUGUI parameters;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        parameters.text = "SCORE: " + scoreValue + "\nHEAL: " + healValue;
        Debug.Log(scoreValue);
    }
}
