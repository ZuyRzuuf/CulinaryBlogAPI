using System;
namespace CulinaryBlog.Infrastructure.Interfaces
{
    public interface IDbSecret
    {
        public string Endpoint { get; set; }
        public string Password { get; set; }
        public string Schema { get; set; }
        public string User { get; set; }
    }
}
