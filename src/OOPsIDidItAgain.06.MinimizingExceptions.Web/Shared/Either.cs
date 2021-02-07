namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared
{
    public static class Either
    {
        public static Either<TLeft, TRight> Left<TLeft, TRight>(TLeft value)
            => new Either<TLeft, TRight>.Left(value);

        public static Either<TLeft, TRight> Right<TLeft, TRight>(TRight value)
            => new Either<TLeft, TRight>.Right(value);
    }

    public abstract class Either<TLeft, TRight>
    {
        private Either()
        {
        }

        public sealed class Left : Either<TLeft, TRight>
        {
            public Left(TLeft value)
            {
                Value = value;
            }

            public TLeft Value { get; }
        }

        public sealed class Right : Either<TLeft, TRight>
        {
            public Right(TRight value)
            {
                Value = value;
            }

            public TRight Value { get; }
        }
    }
}