using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI animalName;

    private void Awake()
    {
        Instance = this;
    }

    public void SetAnimalName(string name)
    {
        animalName.text = name;
    }
}
