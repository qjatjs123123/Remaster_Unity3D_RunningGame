using UnityEngine;

// 3인칭 카메라설정 스크립트
public class ThirdPersonOrbitCamBasic : MonoBehaviour 
{
	public Transform player;                                           // 플레이어참조
	public Vector3 pivotOffset = new Vector3(0.0f, 1.7f,  0.0f);       // 카메라 오프셋
	public Vector3 camOffset   = new Vector3(0.0f, 0.0f, -3.0f);       // 플레이어 위치와 관련된 카메라 위치를 재배치하는 오프셋
    public float smooth = 10f;                                         // 카메라 반응속도
	public float horizontalAimingSpeed = 10f;                           // 수평 회전속도
	public float verticalAimingSpeed = 10f;                             // 수직 회전속도
	public float maxVerticalAngle = 30f;                               // 카메라 최대 각
	public float minVerticalAngle = -60f;                              // 카메라 최소각
	public string XAxis = "Analog X";                                  // 축이름설정
	public string YAxis = "Analog Y";                                  // 축이름설정

	private float angleH = 0;                                          // 마우스 이동 수평 각도 설정
    private float angleV = 0;                                          // 마우스 이동 수직 각도 설정
	private Transform cam;                                             // 카메라
	private Vector3 smoothPivotOffset;                                 // 보간 시 카메라 전류 피벗 오프셋.
    private Vector3 smoothCamOffset;                                   
	private Vector3 targetPivotOffset;                                 
	private Vector3 targetCamOffset;                                   
	private float defaultFOV;                                          
	private float targetFOV;                                           
	private float targetMaxVerticalAngle;                              
	private bool isCustomOffset;                                       

	
	public float GetH { get { return angleH; } }

	void Awake()
	{
		
		cam = transform;

		
		cam.position = player.position + Quaternion.identity * pivotOffset + Quaternion.identity * camOffset;
		cam.rotation = Quaternion.identity;

		
		smoothPivotOffset = pivotOffset;
		smoothCamOffset = camOffset;
		defaultFOV = cam.GetComponent<Camera>().fieldOfView;
		angleH = player.eulerAngles.y;

		ResetTargetOffsets ();
		ResetFOV ();
		ResetMaxVerticalAngle();

		
		if (camOffset.y > 0)
			Debug.LogWarning("Vertical Cam Offset (Y) will be ignored during collisions!\n" +
				"It is recommended to set all vertical offset in Pivot Offset.");
	}

	void Update()
	{
		
		// Mouse:
		angleH += Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1) * horizontalAimingSpeed;
		angleV += Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 1) * verticalAimingSpeed;
		// Joystick:
		angleH += Mathf.Clamp(Input.GetAxis(XAxis), -1, 1) * 60 * horizontalAimingSpeed * Time.deltaTime;
		angleV += Mathf.Clamp(Input.GetAxis(YAxis), -1, 1) * 60 * verticalAimingSpeed * Time.deltaTime;

		// 수직 최대각
		angleV = Mathf.Clamp(angleV, minVerticalAngle, targetMaxVerticalAngle);

		// 카메라 euler설정
		Quaternion camYRotation = Quaternion.Euler(0, angleH, 0);
		Quaternion aimRotation = Quaternion.Euler(-angleV, angleH, 0);
		cam.rotation = aimRotation;

		// Fov 설정
		cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp (cam.GetComponent<Camera>().fieldOfView, targetFOV,  Time.deltaTime);

        // 현재 카메라 위치를 기준으로 환경과의 충돌을 테스트
        Vector3 baseTempPosition = player.position + camYRotation * targetPivotOffset;
		Vector3 noCollisionOffset = targetCamOffset;
		while (noCollisionOffset.magnitude >= 0.2f)
		{
			if (DoubleViewingPosCheck(baseTempPosition + aimRotation * noCollisionOffset))
				break;
			noCollisionOffset -= noCollisionOffset.normalized * 0.2f;
		}
		if (noCollisionOffset.magnitude < 0.2f)
			noCollisionOffset = Vector3.zero;

        //사용자 지정 오프셋의 중간 위치가 없습니다. 1인칭으로 이동
        bool customOffsetCollision = isCustomOffset && noCollisionOffset.sqrMagnitude < targetCamOffset.sqrMagnitude;

        // 카메라를 다시 배치
        smoothPivotOffset = Vector3.Lerp(smoothPivotOffset, customOffsetCollision ? pivotOffset : targetPivotOffset, smooth * Time.deltaTime);
		smoothCamOffset = Vector3.Lerp(smoothCamOffset, customOffsetCollision ? Vector3.zero : noCollisionOffset, smooth * Time.deltaTime);

		cam.position =  player.position + camYRotation * smoothPivotOffset + aimRotation * smoothCamOffset;
	}

    // 카메라 오프셋을 사용자 지정 값으로 설정
    public void SetTargetOffsets(Vector3 newPivotOffset, Vector3 newCamOffset)
	{
		targetPivotOffset = newPivotOffset;
		targetCamOffset = newCamOffset;
		isCustomOffset = true;
	}

    // 카메라 오프셋을 기본값으로 재설정
    public void ResetTargetOffsets()
	{
		targetPivotOffset = pivotOffset;
		targetCamOffset = camOffset;
		isCustomOffset = false;
	}

    // 카메라 수직 오프셋을 재설정
    public void ResetYCamOffset()
	{
		targetCamOffset.y = camOffset.y;
	}

    //카메라 수직 오프셋을 설정
    public void SetYCamOffset(float y)
	{
		targetCamOffset.y = y;
	}

    // 카메라 수평 오프셋을 설정
    public void SetXCamOffset(float x)
	{
		targetCamOffset.x = x;
	}

    // 사용자 정의 시야(FOV) 설정
    public void SetFOV(float customFOV)
	{
		this.targetFOV = customFOV;
	}

	
	public void ResetFOV()
	{
		this.targetFOV = defaultFOV;
	}

	
	public void SetMaxVerticalAngle(float angle)
	{
		this.targetMaxVerticalAngle = angle;
	}

	
	public void ResetMaxVerticalAngle()
	{
		this.targetMaxVerticalAngle = maxVerticalAngle;
	}

	
	bool DoubleViewingPosCheck(Vector3 checkPos)
	{
		return ViewingPosCheck (checkPos) && ReverseViewingPosCheck (checkPos);
	}

	
	bool ViewingPosCheck (Vector3 checkPos)
	{
	
		Vector3 target = player.position + pivotOffset;
		Vector3 direction = target - checkPos;
	
		if (Physics.SphereCast(checkPos, 0.2f, direction, out RaycastHit hit, direction.magnitude))
		{
	
			if(hit.transform != player && !hit.transform.GetComponent<Collider>().isTrigger)
			{
	
				return false;
			}
		}
		
		return true;
	}


	bool ReverseViewingPosCheck(Vector3 checkPos)
	{
	
		Vector3 origin = player.position + pivotOffset;
		Vector3 direction = checkPos - origin;
		if (Physics.SphereCast(origin, 0.2f, direction, out RaycastHit hit, direction.magnitude))
		{
			if(hit.transform != player && hit.transform != transform && !hit.transform.GetComponent<Collider>().isTrigger)
			{
				return false;
			}
		}
		return true;
	}

	
	public float GetCurrentPivotMagnitude(Vector3 finalPivotOffset)
	{
		return Mathf.Abs ((finalPivotOffset - smoothPivotOffset).magnitude);
	}
}
