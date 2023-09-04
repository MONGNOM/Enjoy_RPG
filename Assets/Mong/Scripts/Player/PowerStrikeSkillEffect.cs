using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStrikeSkillEffect : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    private SpriteRenderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        render.flipX = player.render.flipX;   
    }

}
