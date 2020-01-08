using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int healValue = 500;
    Text parameters;

    // Start is called before the first frame update
    void Start()
    {
        parameters = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        parameters.text = "SCORE: " + scoreValue + "\nHEAL: " + healValue;
    }
}
