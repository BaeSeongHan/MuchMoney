using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_map : MonoBehaviour
{
    public GameObject map_x;
    public GameObject map_y;

    public GameObject M;
    public Text map;


    public Slider size_B; //블럭 사이즈 슬라이더


    public void sizeSlider()
    {
        M.GetComponent<MapGenerator>().blockSize = size_B.value;
    }


    public void loadmap()
    {
        map.text = map_x.GetComponent<InputField>().text.ToString() + "x" + map_y.GetComponent<InputField>().text.ToString();


        M.GetComponent<MapGenerator>().mapSize.x = int.Parse(map_x.GetComponent<InputField>().text);
        M.GetComponent<MapGenerator>().mapSize.y = int.Parse(map_y.GetComponent<InputField>().text);
    }
}
