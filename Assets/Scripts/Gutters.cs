using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutters : MonoBehaviour
{
    [SerializeField]
    GameObject left, right;

    public void ToggleGutters()
    {
        left.SetActive(!left.activeSelf);
        right.SetActive(!right.activeSelf);
    }
}
