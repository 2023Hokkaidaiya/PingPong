using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class GameManager : MonoBehaviour
{
    public Agent[] agents;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        Debug.Log("Reset() function called.");
    }

    //�G�s�\�[�h�J�n���ɌĂ΂��
    public void Reset()
    {
        Debug.Log("Reset() function called.");
        //�G�[�W�F���g�ʒu�̃��Z�b�g
        agents[0].gameObject.transform.localPosition = new Vector3(0.0f, 0.5f, -7.0f);
        Debug.Log("agents.Length = " + agents.Length);
        agents[1].gameObject.transform.localPosition = new Vector3(0.0f, 0.5f, 7.0f);

        //�{�[���̈ʒu�Ƒ��x�̃��Z�b�g
        float speed = 10.0f;
        ball.transform.localPosition = new Vector3(0.0f, 0.25f, 0.0f);
        float radius = Random.Range(45f, 135f) * Mathf.PI / 180.0f;
        Vector3 force = new Vector3(
            Mathf.Cos(radius) * speed, 0.0f, Mathf.Sin(radius) * speed);
        if (Random.value < 0.5f) force.z = -force.z;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = force;
    }

    //�G�s�\�[�h�������ɌĂ΂��
    public void EndEpisode(int agentId)
    {
        if(agentId == 0)
        {
            agents[0].AddReward(1.0f);
            agents[1].AddReward(-1.0f);
        }
        else
        {
            agents[0].AddReward(-1.0f);
            agents[1].AddReward(1.0f);
        }
        agents[0].EndEpisode();
        agents[1].EndEpisode();
        Reset();
        Debug.Log("Reset() function called.");
        Debug.Log("EndEpisode() function called.");
    }
}
