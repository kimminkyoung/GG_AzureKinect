using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using Microsoft.Azure.Kinect.BodyTracking;
using System.Globalization;

public class RecordJoint : MonoBehaviour
{
    [SerializeField] List<string> jointName;
    [SerializeField] List<int> jointNum;
    [SerializeField] List<Vector3> jointPos;

    bool checkLoop = false;

    private void OnEnable()
    {
        TrackerHandler.Record += RecordJointPerFrame;
    }
    private void OnDisable()
    {
        TrackerHandler.Record -= RecordJointPerFrame;
    }

    public void RecordJointPerFrame(int maxNum, string name,  int num, Vector3 pos)
    {
        Debug.Log("enum limit is " + num);
        if (!checkLoop)
        {
            jointName.Add(name);
            jointNum.Add(num);
            jointPos.Add(pos);
        }
        else
        {
            jointName[num] = name;
            jointNum[num] = num;
            jointPos[num] = pos;
        }

        if (num == maxNum-1)
        {
            checkLoop = true;
        }
    }
}
