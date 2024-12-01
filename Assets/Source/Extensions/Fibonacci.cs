namespace Extensions
{
    public static class Fibonacci
    {
        public static int Calculate(int x) {
            if (x == 0) return 0;

            int prev = 0;
            int next = 1;
            for (int i = 1; i < x; i++)
            {
                int sum = prev + next;
                prev = next;
                next = sum;
            }
            return next;
        }
    }
}