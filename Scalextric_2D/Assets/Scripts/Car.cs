using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;
using TMPro;

public class Car : MonoBehaviour
{
    private float moveSpeed = 0f;
    private float maxSpeed = 40f;
    private float limitSpeed = 30f;
    private float acceleration = 8f;
    private float deacceleration = 10f;
    private float minSpeed = 0f;

    [SerializeField] TextMeshProUGUI vueltasContadas;
    public int vueltas;
    private bool gameOver = false;
    private bool offTrack = false;
    private Vector3 offTrackDirection;

    public SplineContainer spline;
    private float currentDistance = 0f;
    private int minutes, seconds, cents;
    private float timeElapsed;
    [SerializeField] private TMP_Text cronometroText;
    [SerializeField] public TMP_Text bestlapText;
    [SerializeField] public TMP_Text lastlapText;
    private float bestLap = Mathf.Infinity;
    private float lastLap = 0f;
    //public bool pasoPorMeta = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ContadorVueltas();
        Cronometro();
        if (!gameOver)
        {
            if (Keyboard.current.spaceKey.isPressed)
            {
                moveSpeed = Mathf.MoveTowards(moveSpeed, maxSpeed, acceleration * Time.deltaTime);
            }
            if (!Keyboard.current.spaceKey.isPressed)
            {
                moveSpeed = Mathf.MoveTowards(moveSpeed, minSpeed, deacceleration * Time.deltaTime);
            }
            Debug.Log(moveSpeed);
        }
        if (gameOver)
        {
            moveSpeed = Mathf.MoveTowards(moveSpeed, minSpeed, (15f+deacceleration) * Time.deltaTime);
            transform.position += offTrackDirection * moveSpeed * Time.deltaTime;
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

    public void ContadorVueltas()
    {
        vueltasContadas.text=$"Vueltas:{vueltas}";
        //pasoPorMeta = true;
    }

    public void Cronometro()
    {
        timeElapsed += Time.deltaTime;
        
        cronometroText.text = TimeFormat(timeElapsed);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish")) 
        {
            vueltas++;

            RegistrarVuelta();
        }

        if (other.CompareTag("SalidaPista") && moveSpeed > limitSpeed)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        offTrack = true;

        offTrackDirection = transform.forward;
        Debug.Log("Perdiste");
    }
    public void RegistrarVuelta()
    {
        lastLap = timeElapsed;
        lastlapText.text = "Last: " + TimeFormat(lastLap);

        if (lastLap < bestLap)
        {
            bestLap = lastLap;
            bestlapText.text = "Best: " + TimeFormat(bestLap);
        }
        timeElapsed = 0f;
    }  
    private string TimeFormat(float t)
    {
        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - minutes * 60f);
        cents = (int)((timeElapsed - (int)timeElapsed) * 100f);

        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);;
    }
}
