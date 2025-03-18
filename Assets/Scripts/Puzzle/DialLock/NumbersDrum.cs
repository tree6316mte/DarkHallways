using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NumbersDrum : MonoBehaviour
{
    public GameObject drum;
    private int curCount; // 현재 번호
    public int CurCount {  get { return curCount; } }
    private int lastCount; // 마지막으로 설정한 번호

    private int direction = 1;
    private float rotate = 0f;
    private float deltaRotate = 0f;

    private float[] offsetDrumsMassive;

    private bool rotateUp = false;
    private bool rotateDown = false;

    private bool isCorrect = false;
    public bool IsCorrect { get { return isCorrect; } }
    public int answer; // 임시 정답

    void Awake()
    {
        InitOffsetMassive();
    }

    // Update is called once per frame
    private void Update()
    {
        if (rotateUp)
        {
            RotateDrumUp();
        }
        else if (rotateDown)
        {
            RotateDrumDown();
        }
        else
        {
            rotate = 0.0f;
            deltaRotate = 0.0f;
        }

    }

    void OpenPuzzle()
    {

    }

    private void InitOffsetMassive()
    {

        offsetDrumsMassive = new float[11];

        offsetDrumsMassive[0] = 0.0f;       // 0
        offsetDrumsMassive[1] = 34.934f;    // 1
        offsetDrumsMassive[2] = 69.551f;    // 2
        offsetDrumsMassive[3] = 105.06f;    // 3
        offsetDrumsMassive[4] = 138.716f;   // 4
        offsetDrumsMassive[5] = 173.777f;   // 5
        offsetDrumsMassive[6] = 208.54f;    // 6
        offsetDrumsMassive[7] = 246.286f;   // 7
        offsetDrumsMassive[8] = 290.079f;   // 8
        offsetDrumsMassive[9] = 323.877f;   // 9
        offsetDrumsMassive[10] = 360.0f;    // 0

    }
    private void RotateDrumUp()
    {
        RotateDrum(1);


        if (deltaRotate >= 360.0f)
        {
            drum.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, offsetDrumsMassive[offsetDrumsMassive.Length - 1]));
            rotateUp = false;
        }
    
        else
        {
            if (Mathf.Abs(drum.transform.localEulerAngles.z) >= offsetDrumsMassive[curCount])
            {
                drum.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, offsetDrumsMassive[curCount]));
 
                rotateUp = false;
            }
        }
        if (CheckCode()) Debug.Log("정답");
    }

    private void RotateDrumDown()
    {
        RotateDrum(-1);

        if (curCount == 0)
        {
            if (deltaRotate >= 360.0f)
            {
                drum.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, offsetDrumsMassive[offsetDrumsMassive.Length ]));
                rotateDown = false;
            }
        }
        else
        {
            if (Mathf.Abs(drum.transform.localEulerAngles.z) <= offsetDrumsMassive[curCount])
            {
                drum.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, offsetDrumsMassive[curCount]));
                rotateDown = false;
            }
        }
        if (CheckCode()) Debug.Log("정답");

    }

    private void RotateDrum(int direction)
    {
        rotate = drum.transform.localEulerAngles.z + Time.deltaTime * direction * 80f * direction;
        drum.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, rotate));
        deltaRotate += Time.deltaTime * 80f;
    }
   private bool CheckCode()
    {
        if (curCount == answer) isCorrect = true;
        else isCorrect = false;
        return isCorrect;
    }

    public void DownArrow()
    {
        SoundManager.Instance.PlaySFX("DialScroll");
        rotateUp = true;

        curCount = (curCount - 1 + 10) % 10;

        if (drum.transform.localEulerAngles.z == 0.0f)
            drum.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 359.999f);
        deltaRotate = drum.transform.localEulerAngles.z;
    }
    public void UpArrow()
    {
        SoundManager.Instance.PlaySFX("DialScroll");
        rotateUp = true;

        curCount = (curCount + 1  + 10) % 10;

        deltaRotate = drum.transform.localEulerAngles.z;
    }
}
