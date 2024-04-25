using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public void FlipCharacter(float horizontal)
    {
        if (horizontal != 0)
        {
            float mathfValue = Mathf.Sign(horizontal);
            if (mathfValue == transform.position.x) return;
            transform.localScale = new Vector2(mathfValue, transform.localScale.y);
            
        }
    }
}
