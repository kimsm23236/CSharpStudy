namespace Homework
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DrawAndBet db = new DrawAndBet();
            //db.Start();

            Player player = new Player();
            Knight knight = new Knight();
            Wolf wolf = new Wolf();

            BattleManager battleManager = new BattleManager();
            // 전투 대상 설정, (플레이어, 적)
            battleManager.BattleStart(player, wolf);
            // 전투 시작
            battleManager.ExecuteBattle();
        }
    }
}