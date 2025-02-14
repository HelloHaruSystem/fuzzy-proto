﻿using oopProto.Entities;

namespace oopProto.ItemsAndInventory;

public class Weapon : Item
{
    private int damage;
    private int usesLeft;
    private bool isRanged;

    public Weapon(string itemName, int damage, int usesLeft, bool isRanged) : base(itemName)
    {
        this.itemName = itemName;
        this.damage = damage;
        this.usesLeft = usesLeft;
        this.isRanged = isRanged;
    }
    
    // TODO: add a proper use method
    public override void use()
    {
            
        throw new NotImplementedException();
    }

    // getters and setters
    public int Damage => this.damage;
    public int UsesLeft => this.usesLeft;
    public bool IsRanged => this.isRanged;
}