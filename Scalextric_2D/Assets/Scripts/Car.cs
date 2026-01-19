using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class Car : MonoBehaviour
{
    //GameObject coche = this.GameObject;
    [SerializeField] SplineAnimate spa;

    private float moveSpeed = 0f;
    
    public SplineContainer spline;
    private float currentDistance = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SplineAnimate spa = GetComponent<SplineAnimate>();
        spa = this.GetComponent<SplineAnimate>();
        spa.MaxSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            Debug.Log("Se pulsa");
            moveSpeed = 10f;
        }

        if (!Keyboard.current.spaceKey.isPressed)
        {
            moveSpeed = 0f;
        }

        // Calculate the target position on the spline
        Vector3 targetPosition = spline.EvaluatePosition(currentDistance);

        // Move the character towards the target position on the spline
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Calculate the target rotation on the spline
        Vector3 targetDirection = spline.EvaluateTangent(currentDistance);

        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = targetRotation;
        }

        // If the end of the spline is reached, loop back to the beginning
        if (currentDistance >= 1f)
        {
            currentDistance = 0f;
        }
        else
        {
            // Adjust the movement based on the length of the spline
            float splineLength = spline.CalculateLength();
            float movement = moveSpeed * Time.deltaTime / splineLength;
            currentDistance += movement;
        }

    }
}
