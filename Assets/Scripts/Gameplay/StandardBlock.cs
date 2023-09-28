using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class StandardBlock : MonoBehaviour
{
    #region Filed

    protected  int healthe  = 1;
    protected int point = 1;

    protected AddPointsEvent addPointsEvent = new AddPointsEvent();
    
    BlockDestroyedEvent blockDestroyedEvent = new BlockDestroyedEvent();

    #endregion

    #region Unity Methods

    virtual protected void Start()
    {
        EventManager.AddAddPointsInvoker(this);
        EventManager.AddBlockDestroyedInvoker(this);
    }
    
    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            healthe--;
            if (healthe == 0)
            {
                addPointsEvent.Invoke(point);
                EventManager.RemoveAddPointsInvoker(this);
                blockDestroyedEvent.Invoke();
                EventManager.RemoveBlockDestroyedInvoker(this);
                Destroy(gameObject);
            }
        }
    }

    #endregion

    #region Public Methods

    public void AddAddPointsListener(UnityAction<int> listener)
    {
        addPointsEvent.AddListener(listener);
    }
    
    public void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedEvent.AddListener(listener);
    }

    #endregion

}
