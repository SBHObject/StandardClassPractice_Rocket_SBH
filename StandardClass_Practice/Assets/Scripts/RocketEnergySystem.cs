using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    //���ᷮ�� �����ִ� ������Ʈ
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
