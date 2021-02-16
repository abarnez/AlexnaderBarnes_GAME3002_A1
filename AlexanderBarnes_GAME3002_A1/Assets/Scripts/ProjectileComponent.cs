using UnityEngine.Assertions;
using UnityEngine;
using TMPro;
//[RequireComponent(typeof(Rigidbody))]
public class ProjectileComponent : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vInitialVelocity = Vector3.zero;

    private Rigidbody m_rb = null;

    private GameObject m_landingDisplay = null;

    private bool m_bIsGrounded = true;

    public int Tries;

    public TMP_Text xVelText, yVelText, zVelText, triesText;

    public Canvas gameOverUI;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem! Rigidbody is not attached!");

        CreateLandingDisplay();
        Tries = 3;

       
    }

    private void Update()
    {
        UpdateLandingPosition();

        xVelText.text = "X Velocity: " + m_vInitialVelocity.x;
        yVelText.text = "Y Velocity: " + m_vInitialVelocity.y;
        zVelText.text = "Z Velocity: " + m_vInitialVelocity.z;
        triesText.text = "Tries: " + Tries;

        if(Tries == 0)
        {
            if(Time.frameCount % 15000 == 0)
            gameOverUI.GetComponent<Canvas>().enabled = true;

        }
    }

    private void CreateLandingDisplay()
    {
        m_landingDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        m_landingDisplay.transform.position = Vector3.zero;
        m_landingDisplay.transform.localScale = new Vector3(1f, 0.1f, 1f);

        m_landingDisplay.GetComponent<Renderer>().material.color = Color.blue;
        m_landingDisplay.GetComponent<Collider>().enabled = false;
    }

    private void UpdateLandingPosition()
    {
        if (m_landingDisplay != null && m_bIsGrounded)
        {
            m_landingDisplay.transform.position = GetLandingPosition();
        }
    }

    private Vector3 GetLandingPosition()
    {
        float fTime = 2f * (0f - m_vInitialVelocity.y / Physics.gravity.y);

        Vector3 vFlatVel = m_vInitialVelocity;
        vFlatVel.y = 0f;
        vFlatVel *= fTime;

        return transform.position + vFlatVel;
    }

    #region CALLBACKS
    public void OnLaunchProjectile()
    {
        if (Tries != 0)
        {
            if (!m_bIsGrounded)
            {
                return;
            }

            m_landingDisplay.transform.position = GetLandingPosition();
            m_bIsGrounded = false;

            transform.LookAt(m_landingDisplay.transform.position, Vector3.up);

            m_rb.velocity = m_vInitialVelocity;
            Tries--;
        }
    }
    public void Reset() //resets positions of the ball to where it is when the game starts, also resets the velocity back to zero so it doesnt roll away, and sets isgrounded
    {                   // back to true so you can fire it again
        transform.position = new Vector3(0.0f,0.55f,-20.0f);
        m_bIsGrounded = true;
        m_rb.velocity = Vector3.zero;
        m_rb.angularVelocity = Vector3.zero;
    }

    public void OnMoveForward(float fDelta)
    {
        if (m_vInitialVelocity.z < 50)
            m_vInitialVelocity.z += fDelta;
    }

    public void OnMoveBackward(float fDelta)
    {
        if(m_vInitialVelocity.z > 0)
        m_vInitialVelocity.z -= fDelta;
    }

    public void OnMoveRight(float fDelta)
    {
        if (m_vInitialVelocity.x < 5)
            m_vInitialVelocity.x += fDelta;
    }

    public void OnMoveLeft(float fDelta)
    {
        if (m_vInitialVelocity.x > -5)
           
        m_vInitialVelocity.x -= fDelta;
    }   
    public void OnMoveUp(float fDelta)
    {
        if (m_vInitialVelocity.y < 7.5f)
            m_vInitialVelocity.y += fDelta / 10;
    }
    public void OnMoveDown(float fDelta)
    {
        if (m_vInitialVelocity.y > 0)
            m_vInitialVelocity.y -= fDelta / 10;
    }
    #endregion
}
