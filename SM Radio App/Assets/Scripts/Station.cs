using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

    //Stations must be parented to the Scrollbar!!!!!!!!!

    public string stationName;
    public Color stationColour;
    public Color stationBackgroundColour;
    public float stationFreq;
    public SpriteRenderer sationSprite;
    public SpriteRenderer backgroundSprite;
    public SpriteRenderer vignetteSprite;
    public float logoFadeSpeed = 0.03f;

    SpriteRenderer increments;
    Color incInitColour;
    Color backInitColour;
    Color vignetteInitColour;
    Transform scrollBar;
    FrequencyNumber frequency; 

    AudioSource stationSound;
    public AudioSource staticSound;
    float initStaticSoundVol;

    bool inRange = false;
    

    // Start is called before the first frame update
    void Start()
    {
        stationSound = GetComponent<AudioSource>();
        
        increments = GameObject.Find("Increments").GetComponent<SpriteRenderer>();
        incInitColour = increments.color;
        backInitColour = backgroundSprite.color;
        vignetteInitColour = vignetteSprite.color;


        scrollBar = transform.parent;
        
        
        frequency = scrollBar.gameObject.GetComponent<FrequencyNumber>();

        initStaticSoundVol = staticSound.volume;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(frequency.freqNum - stationFreq) < 2)
        {
            print("boopTrue");
            stationSound.volume = 1.5f - Mathf.Abs(frequency.freqNum - stationFreq);
            staticSound.volume = initStaticSoundVol - (initStaticSoundVol * stationSound.volume);

            increments.color = Color.Lerp(incInitColour, stationColour, 1.5f - Mathf.Abs(frequency.freqNum - stationFreq));
            backgroundSprite.color = Color.Lerp(backInitColour, stationBackgroundColour, 1.5f - Mathf.Abs(frequency.freqNum - stationFreq));
            vignetteSprite.color = backgroundSprite.color;
        }
        else
        {
            stationSound.volume = 0;
            staticSound.volume = initStaticSoundVol;

            increments.color = incInitColour;
            backgroundSprite.color = backInitColour;
            vignetteSprite.color = vignetteInitColour;
        }

        if (stationSound.volume > 0.975f && sationSprite.color.a < 1)
        {
            sationSprite.color = new Color(sationSprite.color.r, sationSprite.color.g, sationSprite.color.b, sationSprite.color.a + logoFadeSpeed);
        }
        else if (stationSound.volume <= 0.975f && sationSprite.color.a > 0)
        {
            sationSprite.color = new Color(sationSprite.color.r, sationSprite.color.g, sationSprite.color.b, sationSprite.color.a - logoFadeSpeed);
        }

    }
}
