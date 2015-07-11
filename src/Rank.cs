namespace Nancy.Simple
{
    public static class Rank
    {
        public static int GetCardValue(string rank)
        {
            int outValue = -1;

            if (int.TryParse(rank, out outValue))
            {
                return outValue;
            }

            switch (rank)
            {
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return -1;
            }
        }
    }
}
