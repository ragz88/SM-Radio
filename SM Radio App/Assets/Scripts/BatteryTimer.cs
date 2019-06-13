using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BatteryTimer : MonoBehaviour
{

    public float timeLimitInSeconds = 1180;
    float currentTimeLeft;

    public SpriteRenderer batery;
    public SpriteRenderer bar;
    public SpriteRenderer pointer;
    public IncContainer increments;

    float blinkTimer = 0;
    public float blinkFrequency = 1.5f;
    bool bateryShowing = true;
    public BarSwipe scrollBar;
    public SpriteRenderer fader;
    Color faderColour;
    public float fadeSpeed = 0.1f;

    
    public Text goodbye;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeLeft = timeLimitInSeconds;
        faderColour = fader.color;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLeft -= Time.deltaTime;

        if (currentTimeLeft >= 600)
        {
            batery.color = increments.spriteColour;
            bar.color = increments.spriteColour;
        }

        if (currentTimeLeft < 600 && currentTimeLeft >= 300)
        //if (currentTimeLeft < 1170 && currentTimeLeft >= 1165)
        {
            bar.gameObject.SetActive(false);
            batery.color = increments.spriteColour;
        }


        if (currentTimeLeft < 300)
        //if (currentTimeLeft < 1160)
        {
            if (bateryShowing)
            {
                batery.color = pointer.color;
                if (blinkTimer > blinkFrequency)
                {
                    batery.color = new Color(0, 0, 0, 0);
                    blinkTimer = 0;
                    bateryShowing = false;
                }
            }
            else
            {
                batery.color = new Color(0, 0, 0, 0);
                if (blinkTimer > (blinkFrequency/2))
                {
                    batery.color = pointer.color;
                    blinkTimer = 0;
                    bateryShowing = true;
                }
            }
        }

        if (currentTimeLeft <= 10)
        {
            scrollBar.enabled = false;
            fader.color = new Color(faderColour.r, faderColour.g, faderColour.b, fader.color.a + fadeSpeed);
            goodbye.color = new Color(goodbye.color.r, goodbye.color.g, goodbye.color.b, fader.color.a);
            if (fader.color.a >= 1)
            {
                SceneManager.LoadScene(2);
            }
        }

        blinkTimer += Time.deltaTime;
    }
}
