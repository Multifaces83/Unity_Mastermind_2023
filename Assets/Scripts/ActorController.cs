using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ActorController : MonoBehaviour
{
    //private IClicObject _usableObject;
    // La vitesse à laquelle le joueur peut regarder autour de lui
    public float mouseSensitivity = 2.0f;
    public float movementSpeed = 0.1f;
    [SerializeField] private TextMeshProUGUI _reticule;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UseTarget(CanClick());

        // Récupère les entrées du clavier et de la souris
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseXInput = Input.GetAxis("Mouse X");
        float mouseYInput = Input.GetAxis("Mouse Y");

        // Déplacement clavier ou souris
        
        transform.position += transform.right * -verticalInput * movementSpeed * Time.deltaTime;
        transform.position += transform.forward * horizontalInput * movementSpeed * Time.deltaTime;

        // la cam suit le mouvement du joueur
        Camera.main.transform.position = transform.position;
        //Debug.DrawRay(transform.position, -transform.up, Color.green);

    }

    private IClicObject CanClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.collider.GetComponent<IClicObject>() != null)
            {
                _reticule.color = Color.green;
                Debug.DrawRay(transform.position, -transform.up, Color.green);
                return hit.collider.GetComponent<IClicObject>();
                
            }
            else
            {
                _reticule.color = Color.white;

            }
        }
        else
        {
            _reticule.color = Color.white;

        }
        return null;
    }
    private void UseTarget(IClicObject usableObject)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && usableObject != null)
        {
            usableObject.ClicOnObject();
        }

    }

}
