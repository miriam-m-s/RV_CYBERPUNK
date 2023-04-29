using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public float time;
    private float _timer;
    public Vector3 rangeExternalAccMin;
    public Vector3 rangeExternalAccMax;
    Cloth cloth_;
    bool isMax;
    // Start is called before the first frame update
    void Start()
    {
        cloth_ = GetComponent<Cloth>();
        _timer = 0;

        cloth_.externalAcceleration = rangeExternalAccMax;
        isMax = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < time){
            _timer += Time.deltaTime;
        }
        else{
            cloth_.externalAcceleration = isMax ? rangeExternalAccMin : rangeExternalAccMax;
            isMax = !isMax;
            _timer = 0;
        }
    }
}
