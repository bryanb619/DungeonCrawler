namespace Dungeon.Characters
{
    public interface ICharacter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        int Hp { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        int AttackPower { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        void Attack(ICharacter target);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        void Heal(int amount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        void TakeDamage(int amount);

    }
}