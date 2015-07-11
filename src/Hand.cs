namespace Nancy.Simple
{
    public enum Hand
    {
        //https://www.briggsoft.com/docs/pmavens/PMHoldem.htm

        Nothing = 0,
        HighCard = 5,
        Pair = 50,
        TwoPair = 100,
        ThreeOfKind = 200,
        Straight = 300,
        Flush = 350,
        FullHouse = 400,
        FourOfKind = 450,
        StraightFlush = 500,
        
    }
}
