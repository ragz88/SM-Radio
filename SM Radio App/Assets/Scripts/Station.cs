using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

    public string stationName;
    public Color stationColour;
    public float stationFreq;

    AudioSource source;
    AudioSource staticSound;
    

    // Start is called before the first frame update
    void Start()
    {
        staticSound = gameObject.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
