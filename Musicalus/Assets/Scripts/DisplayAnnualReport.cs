using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAnnualReport : MonoBehaviour {


    List<double> data;
    RectTransform container;


    // Use this for initialization
    void Start () {
        container = transform.Find("container").GetComponent<RectTransform>();
        container.sizeDelta = new Vector2(Screen.width, Screen.height);
        data = new List<double>();

        //data = CreateReport.getAnnualResults(DateTime.Today.Year);

        float w = Screen.width - Screen.width * 0.05f;
        float h = Screen.height - Screen.height * 0.15f;
        container.sizeDelta = new Vector2(w, h);
        container.position = new Vector3(Screen.width / 2, Screen.height * 0.425f, 0);
        
        data.Add(60);
        data.Add(48);
        data.Add(30);
        data.Add(59);
        data.Add(55);
        data.Add(11);
        data.Add(23);
        data.Add(23);
        data.Add(41);
        data.Add(12);
        data.Add(43);
        data.Add(33);
        
        if (data.Count == 0)
        {
            return;
        }
        else
        {
            display();
        }
    }


    private void display()
    {

        float height = container.sizeDelta.y;
        float yMax = (float)(data.Max() + data.Max() * 0.2);
        float xSize = container.sizeDelta.x / 13;

        for (int i = 0; i < data.Count; i++)
        {
            float x0 = i * xSize + xSize;
            float y0 = (float)(data[i] / yMax) * height;
            createBar(new Vector2(x0, y0), xSize*0.9f, height);
        }

    }

    private void createBar(Vector2 position, float w, float h)
    {
        GameObject obj = new GameObject("bar", typeof(Image));
        obj.transform.SetParent(container, false);
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(position.x, h*0.07f);
        rectTransform.sizeDelta = new Vector2(w, position.y);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0.5f,0f);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
