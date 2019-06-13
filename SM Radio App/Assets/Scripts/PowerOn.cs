using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerOn : MonoBehaviour
{

    public int nextScene = 2;
    public Image fillRing;
    public Image fillIndent;
    public float fillRingSpeed = 0.05f;
    public float fillIndentSpeed = 0.05f;
    //public float pauseTime = 0.75f;

    public AudioSource powerOnSound;
    //float counter = 0;

    bool isOn = false;
    bool soundPlayed = false;

    public SpriteRenderer fader;
    public Color faderColour;
    public float fadeSpeed = 0.1f;

    public Text hello;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            if (soundPlayed == false)
            {
                powerOnSound.Play();
                soundPlayed = true;
            }
            if (fillRing.fillAmount < 1)
            {
                fillRing.fillAmount = fillRing.fillAmount + fillRingSpeed;
            }
            else if (fillIndent.fillAmount < 1)
            {
                fillIndent.fillAmount = fillIndent.fillAmount + fillIndentSpeed;
            }
            else
            {
                //counter += Time.deltaTime;
                
                if (fader.color.a < 1)
                {
                    fader.color = new Color(faderColour.r, faderColour.g, faderColour.b, fader.color.a + fadeSpeed);
                    hello.color = new Color(hello.color.r, hello.color.g, hello.color.b, fader.color.a);
                }
                else
                {
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
    }

    public void powerOn()
    {
        isOn = true;
    }
}
