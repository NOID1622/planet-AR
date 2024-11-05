using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string planetName;
    public string description;
    [SerializeField]
    private float inclineDegrees = 23.4f;
    [SerializeField]
    private float rotationPeriodHours = 24f;
    [SerializeField] 
    private Transform incline;
    [SerializeField] 
    private Transform planet;
    
    public float animationHoursPerSecond = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        incline.Rotate(0f, 0f, inclineDegrees);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rotationPeriodHours * animationHoursPerSecond;
        planet.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
