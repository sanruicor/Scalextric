using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;
using UnityEngine.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    //GameObject coche = this.GameObject;
    [SerializeField] SplineAnimate spa;
    [SerializeField] private Rigidbody2D playerRB;
     [SerializeField] public TextMeshProUGUI vueltasText;
    [SerializeField] private Collider2D meta;
    public int Vueltas = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SplineAnimate spa = GetComponent<SplineAnimate>();
        spa = this.GetComponent<SplineAnimate>();
        spa.MaxSpeed = 50f;
        playerRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vueltasText.text = $"Vueltas: {Vueltas}";
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("He tocado algo");
            if (collision.CompareTag("Finish"))
            {
                Vueltas++;
            }
    }
}
