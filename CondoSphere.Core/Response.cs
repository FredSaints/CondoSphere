using System.Collections.Generic;

namespace CondoSphere.Core
{
    // Non-generic version for service methods that don't return data (e.g., void methods)
    public class Response : Response<object>
    {
        // Static factory methods for non-generic success/fail responses
        public new static Response Success()
        {
            return new Response { Succeeded = true };
        }

        public new static Response Fail(string error)
        {
            return new Response { Succeeded = false, Errors = new List<string> { error } };
        }

        public new static Response Fail(IEnumerable<string> errors)
        {
            return new Response { Succeeded = false, Errors = new List<string>(errors) };
        }
    }

    // Generic version for service methods that return data
    public class Response<T>
    {
        public bool Succeeded { get; protected set; }
        public T? Data { get; protected set; }
        public List<string>? Errors { get; protected set; }

        // Factory method for a successful response with data
        public static Response<T> Success(T data)
        {
            return new Response<T> { Succeeded = true, Data = data };
        }

        // Factory method for a failed response
        public static Response<T> Fail(string error)
        {
            return new Response<T> { Succeeded = false, Errors = new List<string> { error } };
        }

        public static Response<T> Fail(IEnumerable<string> errors)
        {
            return new Response<T> { Succeeded = false, Errors = new List<string>(errors) };
        }
    }
}