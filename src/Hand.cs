namespace Nancy.Simple
{
    public enum Hand
    {
        //https://www.briggsoft.com/docs/pmavens/PMHoldem.htm

        Nothing = 0,
        HighCard = 1,
        Pair = 5,
        TwoPair = 9,
        ThreeOfKind,
        Straight,
        Flush,
        FullHouse,
        FourOfKind,
        StraightFlush

    }
}
