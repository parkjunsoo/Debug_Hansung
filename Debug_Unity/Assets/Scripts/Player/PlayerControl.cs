using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;
    public float jumpSpeed = 5;
    public float downSpeed = 5;

    Vector3 speed;
    float forwardSpeed;
    float sideSpeed;

    float rotLeftRight;
    float rotUpDown;
    float verticalRotation = 0f;
    float verticalVelocity = 0f;


    int layerMask;
    LineRenderer line;
    Ray ray = new Ray();
    RaycastHit hit;
    float timer = 0f;

    PlayerItems items;                                  //PlayerItems 스크립트를 저장할 변수(?)
    
    public Transform lineStart;
    
    CharacterController cc;

    Light LED_Light;

    NumberPad numPad;           //번호패드 스크립트를 저장하기 위함

    // Use this for initialization
    void Awake () {
        items = GetComponent<PlayerItems>();            //player에 붙어있는, 아이템 획득 여부를 판단하는 변수들을 가진 PlayerItems 스크립트를 불러와 저장.
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        LED_Light = Camera.main.GetComponent<Light>();
        LED_Light.enabled = false;

        layerMask = LayerMask.GetMask("PickupItem");
        line = GetComponent<LineRenderer>();

        numPad = GameObject.Find("NumberPad").GetComponent<NumberPad>();
	}

    // Update is called once per frame
    void Update () {
        Move();
        Rotate();
        LED_OnOff();
        Pickup();
    }

    void LED_OnOff()        //E키 입력시 손전등을 on/off하는 함수 - 밝기(intensity) 조절을 통해 켜고 끄는 듯한 효과를 줌.
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (LED_Light.intensity == 0.8f)
                LED_Light.intensity = 0f;
            else
                LED_Light.intensity = 0.8f;
        }
    }

    void Move()         //이동하는 함수. 매 프레임 호출
    {
        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);
    }

    void Rotate()       //시점변경 함수. 매 프레임 호출
    {
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
    
    void Pickup()               //Inspector의 Alignment를 "View"로 설정하여 선(?)을 확인할 수 있고, "Local"로 설정하여 선(?)을 지울 수 있음
    {
        line.SetPosition(0, lineStart.position);                      //lineStart의 position(Inspector에서 연결해줘야 함)
        //ray의 startposition과 방향을 설정
        ray.origin = lineStart.position;
        ray.direction = lineStart.forward;

        if(Physics.Raycast(ray, out hit, 5f, layerMask))                //획득할 아이템의 Layer를 "PickupItem"으로 바꿔야 작동함!!!!!!!!!!!!!!!!!!!
        {
            line.SetPosition(1, hit.point);
            if (hit.collider != null)
            {
                if (hit.collider.name.Contains("Num"))
                {
                    var ex = hit.collider.GetComponent<NumButton>();
                    if (Input.GetKeyDown(KeyCode.F))
                        numPad.Password(ex.input);
                }

                if (hit.collider.name.Contains("Nipper"))               //Ray에 충돌한 collider가 "니퍼"를 포함한 이름을 가질 경우
                {
                    var ex = hit.collider.GetComponent<NipperExample>();        //충돌한 collider의 NipperExample 스크립트를 가져옴
                    if (Input.GetKeyDown(KeyCode.F))
                        ex.Call();                    
                }
                else if (hit.collider.name.Contains("LED"))          //LED일 경우
                {
                    var ex = hit.collider.GetComponent<LEDExample>();
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        ex.Call();
                        LED_Light.intensity = 0f;
                        LED_Light.enabled = true;                   //LED 오브젝트를 삭제하고 플레이어의 손전등 Light를 활성화
                    }
                }
                else if (hit.collider.name.Contains("Lock_Close"))        //Lock일 경우... 니퍼를 획득한 상태인 경우 Mesh를 바꿈
                {
                    var ex = hit.collider.GetComponent<MeshFilter>();
                    var af = GameObject.Find("Lock_Open");           //바꿔줄 mesh를 가진 오브젝트를 저장...
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (items.getNipper)
                        {
                            ex.mesh = af.GetComponent<MeshFilter>().mesh;       //mesh 변경
                            hit.collider.GetComponent<Rigidbody>().useGravity = true;
                        }
                    }
                }
            }
        }
    }
}
