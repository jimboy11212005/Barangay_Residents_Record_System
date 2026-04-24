using BRRAPI.Services;

namespace BRRAPI.Core
{
    public static class ServiceLocator
    {
        public static readonly BarangayService Service = new BarangayService();
    }
}
