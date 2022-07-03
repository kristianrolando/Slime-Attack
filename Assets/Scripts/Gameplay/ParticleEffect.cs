using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] GameObject bloodEffect;
    [SerializeField] GameObject destructEffect;
    [SerializeField] GameObject healthEffect;

    public void Blood(Vector3 coordinate)
    {
        Instantiate(bloodEffect, coordinate, Quaternion.identity);
    }
    public void Destruct(Vector3 coordinate)
    {
        Instantiate(destructEffect, coordinate, Quaternion.identity);
    }
    public void Health(Vector3 coordinate)
    {
        Instantiate(healthEffect, coordinate, Quaternion.identity);
    }


}
