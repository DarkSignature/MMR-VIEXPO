using UnityEngine;

public class TextController : MonoBehaviour
{

    public Canvas canvas;
    public Transform camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // this.enabled = true;
        // this.transform.LookAt(camera.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera);
        transform.Rotate(0, 180f, 0);
        if (Vector3.Distance(camera.position, this.transform.position) > 15f) 
        {
            gameObject.SetActive(false);
        }
    }
}
