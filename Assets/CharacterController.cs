using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; //�̵��ӵ�

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
        moveDirection.Normalize(); //�밢������ �̵��ϴ°� �������°� ����Ͽ� ChatGPT���� ã�ƺý��ϴ�.

        transform.position += (moveDirection * speed * Time.deltaTime);

        //Move(moveDirection * speed * Time.deltaTime); // �÷��̾� �̵�
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
