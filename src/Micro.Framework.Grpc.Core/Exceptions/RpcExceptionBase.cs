namespace Micro.Framework.Grpc.Core.Exceptions
{
    public abstract class RpcExceptionBase : RpcException
    {
        protected RpcExceptionBase(Status status)
            : base(status) { }

        protected RpcExceptionBase(Status status, string message)
            : base(status, message) { }

        protected RpcExceptionBase(Status status, Metadata trailers)
            : base(status, trailers) { }

        protected RpcExceptionBase(Status status, Metadata trailers, string message)
            : base(status, trailers, message) { }
    }
}
