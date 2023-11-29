using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; //이동속도

    void start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f);
        moveDirection.Normalize(); //대각선으로 이동하는게 빨라지는걸 대비하여 ChatGPT에서 찾아봤습니다.

        transform.position += (moveDirection * speed * Time.deltaTime);

        //Move(moveDirection * speed * Time.deltaTime); // 플레이어 이동
    }
    void Move()
    { 
    
    }

    void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) ) 
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;

            transform.LookAt(targetPosition);
        }
    }
}
