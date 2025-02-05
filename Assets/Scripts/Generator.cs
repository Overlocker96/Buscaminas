using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject piece; // Pieza del mapa
    public int width, height,bombsNumber;// Ancho y alto  del mapa
    public GameObject[][] map;

    public static Generator gen;//Variable para hacerlo singleton

    private void Start()
    {
        //Hacemos que sea singleton
        gen = this;

        //Inicializamos el array
        map = new GameObject[width][];

        //Movemos la cámara para que siempre apunte al centro
        Camera.main.transform.position = new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -20);

        //Creamos un array con todos los elementos
        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }

        //Creamos el mapa
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<Piece>().x = i;
                map[i][j].GetComponent<Piece>().y = j;
            }
        }
        SetBombs();

    }//Start

    private void SetBombs()
    {   //Código prueba número de bombas
        for (int i = 0; i < bombsNumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!map[x][y].GetComponent<Piece>().bomb)
            {
                map[x][y].GetComponent<Piece>().bomb = true;
            }
            else
            {
                i--; //Si nos hemos topado con una bomba, tendremos que buscar otra
                //Este bucle no es un representativo
            }
        }
    }

    public int GetBombsAround(int x, int y)
    {
        int cont = 0;
        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (y < height - 1 && map[x][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && map[x - 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && map[x + 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (y > 0 && map[x][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<Piece>().bomb)
            cont++;

        return cont;
    }
}
