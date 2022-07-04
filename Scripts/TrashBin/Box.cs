using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    private enum BoxType
    {
        red,
        blue,
        white
    };

    public enum HitDirection
    {
        Top,
        Bottom,
        Left,
        Right
    };
    HitDirection direction;

    [SerializeField]
    private BoxType CurrentBoxType;
    //[SerializeField]
    //private GameObject marker;

    private Rigidbody m_rigidBody;

    public Transform topIndi;
    public Transform leftIndi;
    public Transform rightIndi;
    public Transform bottomIndi;
    //private int randomValue;
    private int randomcolor;

    public bool isBlue;

    [SerializeField] private float m_speed;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.AddForce(-Vector3.forward * m_speed);
        //randomValue = Random.Range(1, 5);
        randomcolor = Random.Range(1, 3);
        var cubeRenderer = GetComponent<Renderer>();
        if (randomcolor < 1.5)
        {
            cubeRenderer.material.SetColor("_Color", Color.red);
            LayerMask.LayerToName(8);
            isBlue = false;
        }
        if (randomcolor > 1.5)
        {
            cubeRenderer.material.SetColor("_Color", Color.blue);
            LayerMask.LayerToName(9);
            isBlue = true;
        }
    }

    private void Update()
    {
        
        /*if(randomValue == 1)
        {
            Instantiate(marker,topIndi.transform.position, Quaternion.identity);
        }
        if (randomValue == 2)
        {
            Instantiate(marker, leftIndi.transform.position, Quaternion.identity);
        }
        if (randomValue == 3)
        {
            Instantiate(marker, rightIndi.transform.position, Quaternion.identity);
        }
        if (randomValue == 4)
        {
            Instantiate(marker, bottomIndi.transform.position, Quaternion.identity);
        }*/
        
        //marker.transform.position = Vector3.Lerp(transform.position, marker.transform.position, m_speed * Time.deltaTime);
    }

}
