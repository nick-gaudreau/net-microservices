using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using PlatformService.Data;

namespace PlatformService.SyncDataServices.Grpc
{
    // Extends the auto built classes in: PlatformService\obj\Debug\net5.0\Protos
    public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public GrpcPlatformService(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">GetAllRequest is from our proto auto built c# class based of our Proto model</param>
        /// <param name="context">Server side context</param>
        /// <returns></returns>
        public override Task<PlatformResponse> GetAllPlatforms(GetAllRequest request, ServerCallContext context)
        {
            // PlatformResponse from our proto auto built c# class based of our Proto resp
            // which contains a list or platfomr model
            var response = new PlatformResponse();
            var platforms = _repository.GetAllPlatforms();

            foreach(var plat in platforms)
            {
                // GrpcPlatformModel from our proto auto built c# class based of our Proto message model
                response.Platform.Add(_mapper.Map<GrpcPlatformModel>(plat));
            }

            return Task.FromResult(response);
        }
    }
}