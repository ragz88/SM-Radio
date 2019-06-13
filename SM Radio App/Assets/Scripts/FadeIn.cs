using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    SpriteRenderer rend;
    bool faded = false;
    public float fadeSpeed = 0.05f;
    public Text hello;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!faded)
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, rend.color.a - fadeSpeed);
            if (hello != null)
            {
                hello.color = new Color(hello.color.r, hello.color.g, hello.color.b, rend.color.a);
            }
            if (rend.color.a <= 0)
            {
                faded = true;
            }
        }
    }
}
