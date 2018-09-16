using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine.UI;

public class BehaviorTest {


    [UnityTest]
    public IEnumerator noteBehaviorTest()
    {
        SceneManager.LoadScene("Igrica");
        yield return null;

        yield return new WaitForSeconds(0.1f);

        GameObject note = GameObject.FindGameObjectWithTag("NotaCetvrtinka");

        Vector3 position = note.transform.position;

        yield return new WaitForSeconds(2);

        Vector3 newPosition = note.transform.position;

        Assert.IsTrue(newPosition.x<position.x);
    }

    [UnityTest]
    public IEnumerator timerTest()
    {
        SceneManager.LoadScene("Igrica");
        yield return null;

        yield return new WaitForSeconds(3);

        Text timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();

        StringAssert.Contains("3", timer.text);
    }

}
