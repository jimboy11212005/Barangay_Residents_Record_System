using BRRAPI.Services;

namespace BRRAPI.Core
{
    public static class ServiceLocator
    {
        // set from Program.cs so legacy code using this locator works
        public static BarangayService Service { get; set; }
    }
}
