using Dungeon.Items;

namespace Dungeon.Characters
{
    public interface ICharacter
    {
        int Hp { get; set; }
        int AttackPower { get; set; }

        void Attack(ICharacter target);

        void Move();

        void Heal(int amount);

        void TakeDamage(int amount);

        void PickUpItem(Item item);


    }
}