using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodbarBehaviour : MonoBehaviour
{

    public float capacity;

    private float currentCapacity;

    private float originScaleY;

    private float originScaleZ;

    private float originScaleX;

    void Start()
    {
        originScaleY = this.transform.localScale.y;
        originScaleX = this.transform.localScale.x;
        originScaleZ = this.transform.localScale.z;
        currentCapacity = capacity;
    }

    public void DamagedBy(float damage)
    {
        currentCapacity -= damage;
        if (currentCapacity <= 0)
        {
            currentCapacity = 0;
        }
        float currentX = (currentCapacity / capacity) * originScaleX;
        this.transform.localScale = new Vector3(currentX, originScaleY, originScaleZ);
    }
}
