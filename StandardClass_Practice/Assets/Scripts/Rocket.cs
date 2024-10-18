using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    public float Fuel
    {
        get { return fuel; }
    }
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        FuelRestore();
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= FUELPERSHOOT)
        {
            fuel -= FUELPERSHOOT;
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
        }
    }

    public void FuelRestore()
    {
        fuel += 0.1f;
        fuel = Mathf.Clamp(fuel , 0, 100);
    }
}
