using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    //연료량을 보여주는 오브젝트
    [SerializeField]
    private Image fuelAmountUI;

    private Rocket rocket;

    private void Start()
    {
        rocket = GetComponent<Rocket>();
    }

    private void Update()
    {
        DisplayFuelAmount();
    }

    public void DisplayFuelAmount()
    {
        fuelAmountUI.fillAmount = rocket.Fuel / 100;
    }
}
