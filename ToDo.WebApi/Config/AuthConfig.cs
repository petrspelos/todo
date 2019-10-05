using Microsoft.IdentityModel.Tokens;

namespace ToDo.WebApi.Config {
   public static class AuthConfig {
        public static string SecretKey  = "TuqBF-Gc4sC58oHm8EaKCQCTqsxH1SZ6AVUsfBuQE0U";
        public static string SecurityAlgorithm  = SecurityAlgorithms.HmacSha256Signature;
        public static int ExpireSeconds = 86400; //1 day

    }
    
}