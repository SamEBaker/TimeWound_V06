using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButtonBehavior : MonoBehaviour
{

    public int ButtonID;
    public MeshRenderer mr;
    public Material norm;
    public Material pressed;
    public CheckButton c;

    public void Start()
    {
        mr.material = norm;
    }
    public void resetMaterial()
    {
        mr.material = norm;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mr.material = pressed;
            c.AddtoOrder(ButtonID);
        }
    }

    

}
