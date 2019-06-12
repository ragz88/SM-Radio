using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrequencyNumber : MonoBehaviour
{

    //Only on Scrollbar!!!

    public Text freqText;

    [HideInInspector]
    public float freqNum;

    SpriteRenderer increments;

    // Start is called before the first frame update
    void Start()
    {
        increments = GameObject.Find("Increments").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        freqNum = (Mathf.Round(10 * (700 + (-transform.position.x - 50))) / 10);

        freqText.color = increments.color;
        freqText.text = freqNum.ToString();

        //This forces the text to show the 0 decimal point
        if (freqNum % 1 == 0)
        {
            freqText.text = freqText.text + ",0";
        }
    }
}
