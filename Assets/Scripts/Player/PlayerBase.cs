using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerBase : MonoBehaviour
{
    [SerializeField, Tooltip("N")]
    private int lives;
    //можно заменить на public event Action OnLisesZero и синглтон
    [SerializeField]
    UnityEvent LisesZeroEvent;
    [SerializeField]
    protected UnityEvent<int> ChangeLiveValueEvent;
    [SerializeField]
    protected UnityEvent<int> ChangeMoneyEvent;

    private int money;

    //даю возможно изменять значения чтобы можно было добавить фичи которые будут рабоать с золом и жизнями
    public int Lives
    {
        get
        {
            return lives;
        }
        protected set
        {
            if (value <= 0)
                LisesZeroEvent?.Invoke();
            else if (value != lives)
                ChangeLiveValueEvent?.Invoke(value);
            lives = value;
        }
    }
    public int Money
    {
        get { return money; }
        protected set
        {
            if (value != money)
                ChangeMoneyEvent?.Invoke(value);
            money = value;
        }
    }

    public abstract void TakeDamage(int damage);
    public abstract void TakeMoney(int coins);
    public abstract bool CanSpendMoney(int coins);
}
