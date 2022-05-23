public interface IDamagable
{
    int HP { get; }
    int AttackPoint { get; }
    void Damage(int attackPoint);
}
