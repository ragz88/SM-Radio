using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncContainer : MonoBehaviour
{

    public SpriteRenderer[] incrementSprites;
    public Color spriteColour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < incrementSprites.Length; i++)
        {
            incrementSprites[i].color = spriteColour;
        }
    }
}
