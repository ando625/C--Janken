
// ========================================
// Judge.cs：勝敗を判定するクラス
// ========================================

namespace Janken
{
    // 【このクラスの役割】
    // 「グーとチョキならどっちが勝ち？」を判定するだけ
    // 勝敗判定のロジックをここに集める → 他のクラスがスッキリする！
    // 実務でも「1つのクラスに1つの役割」が基本！

    public class Judge
    {
        // =============================================
        // 勝敗の種類を enum で定義
        // 「勝ち・負け・引き分け」の3択しかないから enum にぴったり！
        // =============================================
        public enum Result
        {
            Win,   // プレイヤーの勝ち
            Lose,  // プレイヤーの負け
            Draw   // 引き分け
        }

        // =============================================
        // 勝敗を判定するメソッド
        // 引数：playerHand（プレイヤーの手）、cpuHand（CPUの手）
        // 戻り値：Result（勝ち・負け・引き分けのどれか）
        // =============================================
        public static Result Determine(Hand playerHand, Hand cpuHand)
        {
            // --------- 引き分けチェック ---------
            // 同じ手なら引き分け
            // "==" は「同じかどうか確認する」
            if (playerHand == cpuHand)
            {
                return Result.Draw;
            }

            // --------- 勝ちパターンをチェック ---------
            // プレイヤーが勝つのは以下の3パターン
            // グー(Rock) vs チョキ(Scissors) → 勝ち
            // チョキ(Scissors) vs パー(Paper) → 勝ち
            // パー(Paper) vs グー(Rock) → 勝ち

            // "&&" = 「かつ（両方の条件が true のとき）」
            // "||" = 「または（どちらかが true のとき）」
            bool playerWins =
                (playerHand == Hand.Rock     && cpuHand == Hand.Scissors) ||
                (playerHand == Hand.Scissors && cpuHand == Hand.Paper)    ||
                (playerHand == Hand.Paper    && cpuHand == Hand.Rock);

            // playerWins が true なら勝ち、false なら負け
            // "? :" = 三項演算子（if文を1行で書く省略形）
            // 例：条件 ? 「trueのとき」 : 「falseのとき」
            return playerWins ? Result.Win : Result.Lose;
        }

        // =============================================
        // 手の名前を日本語で返すメソッド
        // Hand.Rock → "グー ✊" のように変換する
        // =============================================
        public static string GetHandName(Hand hand)
        {
            switch (hand)
            {
                case Hand.Rock:     return "グー ✊";
                case Hand.Scissors: return "チョキ ✌️";
                case Hand.Paper:    return "パー ✋";
                // default = 上のどれにも当てはまらないとき
                default:            return "不明";
            }
        }
    }
}