using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public int x;
    public int y;
    public bool bomb;

    private void OnMouseDown()
    {
        if (bomb)
        {
            GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        else
            transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                Generator.gen.GetBombsAround(x,y).ToString();

    }
}
