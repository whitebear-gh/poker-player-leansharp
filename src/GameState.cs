namespace Nancy.Simple
{
    public class GameState
    {
        string tournament_id;

        string game_id;

        int round;

        int bet_index;

        int small_blind;

        int current_buy_in;

        int pot;

        int minimum_raise;

        int dealer;

        int orbits;

        int in_action;

        Player[] players;

        Card[] communityCards;

    }
}
