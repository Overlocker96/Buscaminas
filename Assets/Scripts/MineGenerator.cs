using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGenerator : MonoBehaviour
{
    public GameObject Cell;// Elemento Principal
    public int Width, Height;// Ancho y alto  del mapa
    public int Bombs;// Cantidad de Bombas
    public int maxBombs;

    void Start()
    {
        maxBombs = Bombs;
        GenerateMinefield();
    }

    private void GenerateMinefield()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Instantiate(Cell, new(x, y), Quaternion.identity);
                if (Bombs > 0 && Random.Range(0,Width*Height) < maxBombs)
                {
                    Cell.GetComponent<SpriteRenderer>().color = Color.red;
                    Bombs--;
                }
                else
                {
                    Cell.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
    void Update()
    {
        
    }
}
