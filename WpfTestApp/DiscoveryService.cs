using Google.Apis.Services;

namespace DataParallelismWithForEach
{
    internal class DiscoveryService
    {
        private BaseClientService.Initializer initializer;

        public DiscoveryService(BaseClientService.Initializer initializer)
        {
            this.initializer = initializer;
        }

        public object Apis { get; internal set; }
    }
}