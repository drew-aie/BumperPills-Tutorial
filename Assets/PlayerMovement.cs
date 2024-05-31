using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1000;
    public float JumpForce = 300;
    public bool IsPlayerOne = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool leftInput;
        bool rightInput;
        bool jumpInput;
        if (IsPlayerOne)
        {
            leftInput = Input.GetKey(KeyCode.A);
            rightInput = Input.GetKey(KeyCode.D);
            jumpInput = Input.GetKeyDown(KeyCode.W);
        }
        else
        {
            leftInput = Input.GetKey(KeyCode.LeftArrow);
            rightInput = Input.GetKey(KeyCode.RightArrow);
            jumpInput = Input.GetKeyDown(KeyCode.UpArrow);
        }

        // Jump
        if (jumpInput)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }

        // Horizontal movement
        int direction = 0;
        if (leftInput)
        {
            direction = -1;
        }
        else if (rightInput)
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        Vector3 force = new Vector3(Speed, 0, 0) * direction;
        GetComponent<Rigidbody>().AddForce(force * Time.deltaTime);
    }
}
