using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float MaxTime = 60f;

    [SerializeField]
    private float CountDown = 0;

    void Awake()
    {
        CountDown = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        if(CountDown < 0 )
        {
            Coin.CoinCount = 0;
            SceneManager.LoadScene("level__01");
        }
    }
}
