using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class InformationHolder {

    public static int score = 0;
    public static int timer = 0;

    static int currentSpeed = 0;
    static int currentSong = 0;


    static float[] speeds = new float[3] {6f, 10f, 15f};
    static string[] songs = new string[3] {"Melody of Tears", "Clair de Lune","Moonlight Sonata"};

    public static int CurrentSpeed
    {
        get
        {
            return currentSpeed;
        }

        set
        {
            currentSpeed = value;
        }
    }

    public static int CurrentSong
    {
        get
        {
            return currentSong;
        }

        set
        {
            currentSong = value;
        }
    }

    public static float getSpeed(int index)
    {
        if (index<3)
        {
            return speeds[index];
        }

        throw new IndexOutOfRangeException();

    }

    public static string getSong(int index)
    {
        if (index < 3)
        {
            return songs[index];
        }

        throw new IndexOutOfRangeException();

    }
}
