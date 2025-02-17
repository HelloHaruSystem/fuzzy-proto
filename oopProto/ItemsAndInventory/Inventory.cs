using System;
using System.Collections.Generic;

namespace oopProto.ItemsAndInventory;

public class Inventory
{
    private List<Item> items;
    private int maxCapacity;
    private int currentCapacity;

    public Inventory()
    {
        items = new List<Item>();
        maxCapacity = 10;
        currentCapacity = 0;
    }

    public void AddItem(Item item)
    {
        if (currentCapacity >= maxCapacity)
        {
            Console.WriteLine("Inventory is full");
        }
        else
        {
            items.Add(item);
            currentCapacity++;
        }
    }

    // TODO: implement the swap method!
    public void SwapItems(Item itemToReplace, Item newItem)
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(Item item)
    {
        this.items.Remove(item);
        currentCapacity--;
    }

    public void ShowInventory()
    {
        Console.WriteLine("Items:");
        for (int i = 0; i < items.Count; i++)
        {
            if (i % 5 == 0)
            {
                Console.WriteLine();
            }

            Console.Write($"[1]: {items[i]}\t");
        }
    }

    public void AddMaxCapacity(int increasedCapacity)
    {
        this.maxCapacity += increasedCapacity;
    }
    
    // Getters and setters
    public int Maxcapacity { get => maxCapacity; set => maxCapacity = value; }
    public int CurrentCapacity { get => currentCapacity; set => currentCapacity = value; }
}