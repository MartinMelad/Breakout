using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectBlock : StandardBlock
{
    #region Filed

    [SerializeField] private Sprite freezerSprite;

    [SerializeField] private Sprite speedupSprite;
    
    EffectName effect;

    private float duration;

    private FeezerEffectActivatedEvent feezerEffectActivatedEvent;

    private float speedupForce;

    private SpeedupEffectActivatedEvent speedupEffectActivatedEvent;

    #endregion

    #region Property

    public EffectName Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == EffectName.Freezer)
            {
                spriteRenderer.sprite = freezerSprite;
                duration = ConfigurationUtils.FreezerEffectDuration;
                feezerEffectActivatedEvent = new FeezerEffectActivatedEvent();
                EventManager.AddFreezerEffectActivatedInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                speedupEffectActivatedEvent = new SpeedupEffectActivatedEvent();
                duration = ConfigurationUtils.SpeedupEffectDuration;
                speedupForce = ConfigurationUtils.SpeedupEffectForce;
                EventManager.AddSpeedupEffectActivatedInvoker(this);
            }
        }
    }    

    #endregion

    #region Unity Methodes
    
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        healthe = 3;
        point = ConfigurationUtils.EffectBlock;
        
    }

    // Update is called once per frame

    override protected void OnCollisionEnter2D(Collision2D col)
    {
        if (effect == EffectName.Freezer && healthe == 1)
        {
            AudioManager.Play(AudioClipName.FreezerEffectActivated);
            feezerEffectActivatedEvent.Invoke(duration);
            EventManager.RemoveFreezerEffectActivatedInvoker(this);
        }
        else if (effect == EffectName.Speedup && healthe == 1)
        {
            AudioManager.Play(AudioClipName.SpeedupEffectActivated);
            speedupEffectActivatedEvent.Invoke(duration,speedupForce);
            EventManager.RemoveSpeedupEffectActivatedInvoker(this);
        }
        
        base.OnCollisionEnter2D(col);
    }
    #endregion

    #region Public Methodes

    public void AddFreezerEffectActivatedListener(UnityAction<float> listener)
    {
        feezerEffectActivatedEvent.AddListener(listener);
    }
    
    public void AddSpeedupEffectActivatedListener(UnityAction<float,float> listener)
    {
        speedupEffectActivatedEvent.AddListener(listener);
    }

    #endregion
}
