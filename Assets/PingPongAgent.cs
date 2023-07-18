using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;

public class PingPongAgent : Agent
{
    public int agentId;
    public GameObject ball;
    Rigidbody ballRb;

    //�Q�[���I�u�W�F�N�g�������ɌĂ΂��
    public override void Initialize()
    {
        this.ballRb = this.ball.GetComponent<Rigidbody>();
    }

    //�ώ@�擾���ɌĂ΂��
    public override void CollectObservations(VectorSensor sensor)
    {
        float dir = (agentId == 0) ? 1.0f : -1.0f;
        sensor.AddObservation(this.ball.transform.localPosition.x * dir); //�{�[����X���W
        sensor.AddObservation(this.ball.transform.localPosition.z * dir); //�{�[����Z���W
        sensor.AddObservation(this.ballRb.velocity.x * dir); //�{�[����X���x
        sensor.AddObservation(this.ballRb.velocity.z * dir); //�{�[����Z���x
        sensor.AddObservation(this.transform.localPosition.x * dir); //�p�h���̑��x
    }

    //�{�[���ƃp�h���̏ՓˊJ�n���ɌĂ΂��
    private void OnCollisionEnter(Collision collision)
    {
        //��V
        AddReward(0.1f);
    }

    //�s���J�n���ɌĂ΂��
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        //PingPongAgent�̈ړ�
        float dir = (agentId == 0) ? 1.0f : -1.0f;
        int action = actionBuffers.DiscreteActions[0];
        Vector3 pos = this.transform.localPosition;
        if(action == 1)
        {
            pos.x -= 0.2f * dir;
        }
        else if (action == 2)
        {
            pos.x += 0.2f * dir;
        }
        if (pos.x < -4.0f) pos.x = -4.0f;
        if (pos.x > 4.0f) pos.x = 4.0f;
        this.transform.localPosition = pos;
    }

    //�q���[���X�e�B�b�N���[�h�s�����莞
    public override void Heuristic(in ActionBuffers actionBuffers)
    {
        var actionsOut = actionBuffers.DiscreteActions;
        actionsOut[0] = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) actionsOut[0] = 1;
        if (Input.GetKey(KeyCode.RightArrow)) actionsOut[0] = 2;
    }
}
