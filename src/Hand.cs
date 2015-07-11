namespace Nancy.Simple
{
    public enum Hand
    {
        //https://www.briggsoft.com/docs/pmavens/PMHoldem.htm

        Nothing = 0,
        HighCard = 5,
        Pair = 150,
        TwoPair = 200,
        ThreeOfKind = 250,
        Straight = 300,
        Flush = 350,
        FullHouse = 400,
        FourOfKind = 450,
        StraightFlush = 500,
        
    }
}
