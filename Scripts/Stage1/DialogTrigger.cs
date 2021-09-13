using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialogue info;

    public void Trigger()
    {
        var system = FindObjectOfType<DialogManager>();
        system.Begin(info);
    }
}
