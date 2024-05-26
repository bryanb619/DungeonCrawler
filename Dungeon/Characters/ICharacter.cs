namespace Dungeon.Characters
{
    public interface ICharacter
    {
        /// <summary>
        /// Hp property
        /// </summary>
        /// <value></value>
        int Hp { get; set; }


        /// <summary>
        /// Attack power property
        /// </summary>
        /// <value></value>
        int AttackPower { get; set; }

        /// <summary>
        /// Receives an ICharacter object as a parameter and attacks it
        /// </summary>
        /// <param name="target"></param>
        void Attack(ICharacter target);


        /// <summary>
        /// Take damage method
        /// </summary>
        /// <param name="amount"></param>
        void TakeDamage(int amount);

        /// <summary>
        /// Detect if the character is dead
        /// </summary>
        /// <returns></returns>
        bool Dead();

    }
}