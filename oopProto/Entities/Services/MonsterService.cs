namespace oopProto.Entities.Services;

public class MonsterService
{
    private List<Monster> monsters;

    public MonsterService()
    {
        this.monsters = LoadMonsters();
    }

    // TODO load monsters
    private List<Monster> LoadMonsters()
    {
        throw new NotImplementedException();
    }
    
    public int Attack(Monster monster)
    {
        int dealtDmg = monster.Strength + monster.EquipedWeapon.Damage;
       
        return dealtDmg;
    }
    
}