using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _fillBar;
    public void SetHealth(float setHealth)
    {
        print(setHealth);
        _fillBar.transform.localScale = new Vector3((setHealth + 100) / 100, 1, 1);
    }
}
