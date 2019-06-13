using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

    //Stations must be parented to the Scrollbar!!!!!!!!!

    public string stationName;
    public Color stationColour;
    public Color stationBackgroundColour;
    public Color pointerColour;
    public float stationFreq;
    public SpriteRenderer stationSprite;
    public SpriteRenderer backgroundSprite;
    public SpriteRenderer vignetteSprite;
    public float logoFadeSpeed = 0.03f;

    IncContainer increments;
    SpriteRenderer arrow;
    Color incInitColour;
    Color backInitColour;
    Color vignetteInitColour;
    Color arrowInitColour;
    Transform scrollBar;
    FrequencyNumber frequency; 

    AudioSource stationSound;
    public AudioSource staticSound;

    public float clearWidth = 2;
    float initStaticSoundVol;

    bool inRange = false;
    

    // Start is called before the first frame update
    void Start()
    {
        stationSound = GetComponent<AudioSource>();
        
        increments = GameObject.Find("IncrementsContainer").GetComponent<IncContainer>();
        arrow = GameObject.Find("Pointer").GetComponent<SpriteRenderer>();
        incInitColour = increments.spriteColour;
        backInitColour = backgroundSprite.color;
        vignetteInitColour = vignetteSprite.color;

        arrowInitColour = arrow.color;

        scrollBar = transform.parent;
        
        
        frequency = scrollBar.gameObject.GetComponent<FrequencyNumber>();

        initStaticSoundVol = staticSound.volume;

        stationSound.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(frequency.freqNum - stationFreq) < clearWidth)
        {
            //print("boopTrue");
            stationSound.volume = (clearWidth*0.75f) - Mathf.Abs(frequency.freqNum - stationFreq);
            staticSound.volume = initStaticSoundVol - (initStaticSoundVol * stationSound.volume);

            increments.spriteColour = Color.Lerp(incInitColour, stationColour, (clearWidth * 0.75f) - Mathf.Abs(frequency.freqNum - stationFreq));
            arrow.color = Color.Lerp(arrowInitColour, pointerColour, (clearWidth * 0.75f) - Mathf.Abs(frequency.freqNum - stationFreq));
            stationSprite.color = new Color(increments.spriteColour.r, increments.spriteColour.g, increments.spriteColour.b, stationSprite.color.a);
            backgroundSprite.color = Color.Lerp(backInitColour, stationBackgroundColour, (clearWidth * 0.75f) - Mathf.Abs(frequency.freqNum - stationFreq));
            vignetteSprite.color = backgroundSprite.color;
        }
        else if (Mathf.Abs(frequency.freqNum - stationFreq) < (clearWidth + 1))
        {
            stationSound.volume = 0;
            staticSound.volume = initStaticSoundVol;
            stationSprite.color = new Color(incInitColour.r, incInitColour.g, incInitColour.b, 0);
            increments.spriteColour = incInitColour;
            arrow.color = arrowInitColour;
            backgroundSprite.color = backInitColour;
            vignetteSprite.color = vignetteInitColour;
        }
        else if (Mathf.Abs(frequency.freqNum - stationFreq) >= (clearWidth + 1))
        {
            stationSound.volume = 0;
            stationSprite.color = new Color(incInitColour.r, incInitColour.g, incInitColour.b, 0);
        }

        if (stationSound.volume > 0.975f && stationSprite.color.a < 1)
        {
            stationSprite.color = new Color(stationSprite.color.r, stationSprite.color.g, stationSprite.color.b, stationSprite.color.a + logoFadeSpeed);
        }
        else if (stationSound.volume <= 0.975f && stationSprite.color.a > 0)
        {
            stationSprite.color = new Color(stationSprite.color.r, stationSprite.color.g, stationSprite.color.b, stationSprite.color.a - logoFadeSpeed);
        }

    }
}
