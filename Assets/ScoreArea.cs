using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�R�A�G���A
public class ScoreArea : MonoBehaviour
{
    public GameManager gameManager;
    public int agentId;

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        gameManager.EndEpisode(agentId);
    }
}
