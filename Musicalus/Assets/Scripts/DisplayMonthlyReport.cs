using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMonthlyReport : MonoBehaviour {

    List<int> data;
    RectTransform container;
    public Sprite point;

	// Use this for initialization
	void Start () {

        container = transform.Find("container").GetComponent<RectTransform>();
        
        data = new List<int>();
        data = CreateReport.getMonthlyResults(DateTime.Today.Month, DateTime.Today.Year);

        float w = Screen.width - Screen.width * 0.05f;
        float h = Screen.height - Screen.height * 0.15f;
        container.sizeDelta = new Vector2(w, h);
        container.position = new Vector3(Screen.width / 2, Screen.height * 0.425f, 0);
        /*
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
        data.Add(23);
        data.Add(43);
        data.Add(53);
        data.Add(23);
        data.Add(24);
        data.Add(25);
        data.Add(26);
        data.Add(37);
        data.Add(40);
        data.Add(45);
        data.Add(58);
        data.Add(59);
        data.Add(51);
        data.Add(41);
        data.Add(60);
        data.Add(23);
        data.Add(33);
        data.Add(13);
        */
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
        float yMax = (float)(data.Max()+ data.Max()*0.2);
        float xSize = container.sizeDelta.x/32;

        for (int i=0; i<data.Count; i++)
        {
            float x0 = i * xSize+15f;
            float y0 = (data[i]/yMax) * height;
            createPoint(new Vector2(x0,y0));
        }

    }

    void createPoint(Vector2 position)
    {
        GameObject obj = new GameObject("point", typeof(Image));
        obj.transform.SetParent(container, false);
        obj.GetComponent<Image>().sprite = point;
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(30, 30);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update () {
    }
}
