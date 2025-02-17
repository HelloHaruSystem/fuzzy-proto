using System.Collections.Generic;
using oopProto.Layout;

namespace oopProto.Entities;

public abstract class Entity
{
    protected int maxHp;
    protected int currentHp;

    protected Entity()
    {
        this.currentHp = maxHp;
    }

    public void RecieveDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
    }

    public void RecieveHeal(int heal)
    {
        currentHp += heal;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
    
    // getters and setters
    public int MaxHp { get => maxHp; set => maxHp = value; }
    public int CurrentHp { get => currentHp; set => currentHp = value; }
}