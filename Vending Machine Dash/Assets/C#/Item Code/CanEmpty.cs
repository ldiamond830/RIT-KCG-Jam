using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Memo 
//[GameObject].GetComponentInParent<CanEmpty>();

public class CanEmpty : Item
{

    /// <summary>
    /// Time that a person is inactive due to being hit by a can.(seconds)<br/>
    /// ��e���čs���s�\�ɂȂ鎞��(�b)
    /// </summary>
    public float RestraintTime { get; private set; }

    /// <summary>
    /// Amount of money lost if attacked.<br/>
    /// ��e�����痎�Ƃ������̗�
    /// </summary>
    public int LostMoney { get; private set; }

    /// <summary>
    /// Speed of throwing cans. <br/>
    /// �ʂ𓊂��鑬�x
    /// </summary>
    public float ThrowingSpeed { get; private set; }


    //�ʂ̃v���O�����Ŏ������悤�������Ă��邪�A�v���C���[�Ŏ�����������������������Ȃ��B
    //I am not sure whether to implement it in the can program,
    //but it might be better to implement it in the player.
    ///// <summary>
    ///// Process when collision into a player.<br/>
    ///// �v���C���[�ɓ����������̏���
    ///// </summary>
    //public Action<PlayerUI> OnHitPlayer;


    // Start is called before the first frame update
    void Start()
    {
        Type = ItemTypes.CAN_EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Set parameter
    public void Init(float _restraintTime, int _lostMoney, float _throwingSpeed)
    {
        RestraintTime = _restraintTime;
        LostMoney = _lostMoney;
        ThrowingSpeed = _throwingSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If CanEmpty and Player collide
        if (collision.collider.CompareTag("Player"))
        {
            //Get PlayerUI
            var playerUI = collision.gameObject.GetComponent<PlayerUI>();

            if (playerUI != null)
            {
                //Distinguish between 20JPY and the rest.
                if (LostMoney < 0)
                {//20JPY

                    //Lost all money
                    playerUI.Coins = 0;
                }
                else
                {//other

                    //Lost money
                    playerUI.Coins -= LostMoney;
                }
            }

            //Delete this Can
            Destroy(this);
        }
    }
}
