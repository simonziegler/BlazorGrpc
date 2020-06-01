﻿using Grpc.Core;
using GrpcGreeter;
using System.Threading.Tasks;

namespace BlazorGrpc.Server
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var reply = new HelloReply { Message = $"Hello from gRPC, {request.Name}!" };
            return Task.FromResult(reply);
        }
    }
}
