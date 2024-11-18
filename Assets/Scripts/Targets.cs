using UnityEngine;

public class Targets : MonoBehaviour
{
    public string Mykey;
    public bool PressedDown;
    public PressurePlateManager pm;
    public MeshRenderer mr;
    public Material material;
    public Material pressed;

    // Start is called before the first frame update
    public void Clear()
    {
        pm.Removepressed();
        mr.material = material;
        //playsound
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == Mykey)
        {
            Debug.Log("I am pressed");
            mr.material = pressed;
            pm.Addpressed();
        }

    }
}
