using System;

namespace UltraLogger.Core.Application.Common.ResultPattern
{
    public sealed class Result
    {
        private Result()
        {
            IsSuccess = true;
            Error = Error.None;
        }

        private Result(Error error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            IsSuccess = false;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public static implicit operator Result(Error error) => new Result(error);
        public static Result Success() => new Result();
        public static Result Failure(Error error) => new Result(error);
    }

    public sealed class Result<TValue>
    {
        private readonly Result _result;
        private readonly TValue _value;

        private Result(TValue value)
        {
            _result = Result.Success();
            _value = value;
        }

        private Result(Error error)
        {
            _result = Result.Failure(error);
            _value = default;
        }

        public bool IsSuccess => _result.IsSuccess;
        public bool IsFailure => _result.IsFailure;
        public TValue Value => IsSuccess ? _value : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");
        public Error Error => _result.Error;
        public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error);
        public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);
        public static Result<TValue> Success(TValue value) => new Result<TValue>(value);
        public static Result<TValue> Failure(Error error) => new Result<TValue>(error);
    }
}
