// ========================================
// Program.cs：アプリの入り口
// ========================================

namespace Janken
{
    class Program
    {
        static void Main(string[] args)
        {
            // GameManager を作ってゲームを開始するだけ！
            // 全部の処理は GameManager に任せる
            // これが「役割を分ける」設計の良さ！
            GameManager game = new GameManager();
            game.Start();
        }
    }
}