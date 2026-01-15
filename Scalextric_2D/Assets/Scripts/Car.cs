using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;
using UnityEngine.Splines;

public class Car : MonoBehaviour
{
    //GameObject coche = this.GameObject;
    [SerializeField] SplineAnimate spa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SplineAnimate spa = GetComponent<SplineAnimate>();
        spa = this.GetComponent<SplineAnimate>();
        spa.MaxSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
