using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] GameObject ground;
    [SerializeField] List<Tile> tileArr;

    [SerializeField] public GameObject city1;  //Starting city 
    [SerializeField] public GameObject city2;  //Middle Size city 
    [SerializeField] public GameObject city3;  //Big Size city, Middle Ground
    [SerializeField] public GameObject city4;  //Big Size city, Green
    [SerializeField] public GameObject city5;  //Big Size city, Polluted

    public List<int> infoLoad;

    //call this everytime a new object is placed!!!
    public void BuildCity()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("BuildData.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("build");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if (int.Parse(mydoc.SelectSingleNode("build/buildAmount").InnerText.Trim()) >= 0 && int.Parse(mydoc.SelectSingleNode("build/buildAmount").InnerText.Trim()) < 15)
            {
                city1.SetActive(true);
                city2.SetActive(false);
                city3.SetActive(false);
                city4.SetActive(false);
                city5.SetActive(false);
            }

            else if(int.Parse(mydoc.SelectSingleNode("build/buildAmount").InnerText.Trim()) >= 15 && int.Parse(mydoc.SelectSingleNode("build/buildAmount").InnerText.Trim()) < 50)
            {
                city1.SetActive(false);
                city2.SetActive(true);
                city3.SetActive(false);
                city4.SetActive(false);
                city5.SetActive(false);
            }

            else if(int.Parse(mydoc.SelectSingleNode("build/buildAmount").InnerText.Trim()) >= 50 && int.Parse(mydoc.SelectSingleNode("build/cityGreenIndex").InnerText.Trim()) > -50 && int.Parse(mydoc.SelectSingleNode("build/cityGreenIndex").InnerText.Trim()) < 50)
            {
                city1.SetActive(false);
                city2.SetActive(false);
                city3.SetActive(true);
                city4.SetActive(false);
                city5.SetActive(false);
            }

            else if (int.Parse(mydoc.SelectSingleNode("build/buildAmount").InnerText.Trim()) >= 50 && int.Parse(mydoc.SelectSingleNode("build/cityGreenIndex").InnerText.Trim()) >= 50)
            {
                city1.SetActive(false);
                city2.SetActive(false);
                city3.SetActive(false);
                city4.SetActive(true);
                city5.SetActive(false);
            }

            else if (int.Parse(mydoc.SelectSingleNode("build/buildAmount").InnerText.Trim()) >= 50 && int.Parse(mydoc.SelectSingleNode("build/cityGreenIndex").InnerText.Trim()) <= -50)
            {
                city1.SetActive(false);
                city2.SetActive(false);
                city3.SetActive(false);
                city4.SetActive(false);
                city5.SetActive(true);
            }
        }
    }

    void Start()
    {
        //tileArr = new Tile[_width * _height];
        //infoLoad = new int[tileArr.Length];

        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("BuildData.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("build");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if (mydoc.SelectSingleNode("build/buildNewTrue").InnerText.Trim().Equals("True"))
            {
                mydoc.SelectSingleNode("build/buildStats").InnerText = "";

                for (int i = 0; i < (_width * _height); i++)
                {
                    //0 means the selected location is empty (no buildings)!
                    mydoc.SelectSingleNode("build/buildStats").InnerText += "0";
                    infoLoad.Add(0);
                }
                mydoc.SelectSingleNode("build/buildAmount").InnerText = "0";
                mydoc.SelectSingleNode("build/cityGreenIndex").InnerText = "0";
                mydoc.Save("BuildData.xml");
            }

            if (mydoc.SelectSingleNode("build/buildNewTrue").InnerText.Trim().Equals("False"))
            {
                if (mydoc.SelectSingleNode("build/buildStats").InnerText.Trim().Length > 0)
                {
                    for (int i = 0; i < (_width * _height); i++)
                    {
                        infoLoad.Add(mydoc.SelectSingleNode("build/buildStats").InnerText.Trim()[i]);
                        //Buradan sonra infoload� ya da direkt XML'i kullanarak verileri tile'lara atacak ve olan de�i�imleri XML'E KAYDEDECE��M
                        // DE����MLER� TEMPORARY OLARAK infoload'da tutarak ��karken XML'E kaydetmek s�rekli read yapmay� azaltabilir!
                    }
                    mydoc.Save("BuildData.xml");
                }
                else
                {
                    Debug.Log("The game is loaded, but the grids are empty. IMPOSSIBLE, YOU CANNOT LOAD EMPTY GAME!");
                }

            }
        }

        BuildCity();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        int cnt = 0;

        for(int a = 0; a < _width; a++)
        {
            for (int b = 0; b < _height; b++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(a, 0, b), Quaternion.identity);
                spawnedTile.transform.Rotate(90, 0, 0);
                spawnedTile.name = $"Tile {a}, {b}";
                tileArr.Add(spawnedTile);
                cnt++;
            }
        }

        _cam.transform.position = new Vector3(((float) _width / 2), (float) (_height / 2) -3f, 0);
    }
}   
