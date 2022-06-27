using RESTWithASP_NET5Udemy.Data.VO;
using RESTWithASP_NET5Udemy.Model;
using RESTWithASP_NET5Udemy.Model.Context;
using System.Security.Cryptography;
using System.Text;

namespace RESTWithASP_NET5Udemy.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;
        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = Hashing.ToSHA256(user.Password);
            var result = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == pass);
            return result;
        }
        public static class Hashing
        {
            internal static string ToSHA256(string pass)
            {
                using var sha256 = SHA256.Create();
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));

                var sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(p => p.Id == user.Id)) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id == user.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return user;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;

        }
        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);

        }

    }
}
