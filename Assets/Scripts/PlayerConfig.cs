public class PlayerConfig
{
    public string playerName = "";
    public float moveSpeed;
    public float jumpForce;
    public float health;
    public float damage;

    public PlayerConfig(string playerName, float moveSpeed, float jumpForce, float health, float damage)
    {
        this.playerName = playerName;
        this.moveSpeed = moveSpeed;
        this.jumpForce = jumpForce;
        this.health = health;
        this.damage = damage;
    }
}
