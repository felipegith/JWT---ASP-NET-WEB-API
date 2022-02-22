using Jesstw.Model;
using Jesstw.Context;
using System.Linq;
using System;
using System.Text;
using System.Security.Cryptography;

namespace Jesstw.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ServerContext _context;

        public UserRepository(ServerContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            try
            {
                var checkEmail = _context.Users.SingleOrDefault(e => e.Email.Equals(user.Email));

                if (checkEmail == null)
                {
                    var passwordHash = Hashed(user.Password, new SHA256CryptoServiceProvider());
                    user.Password = passwordHash;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            catch
            {

            }
            return user;
        }

        public User ValidateCredentials(UserVO user)
        {
            throw new System.NotImplementedException();
        }

        public User ValidateCredentialsRefreshToken(string Email)
        {
            throw new System.NotImplementedException();
        }

        public string Hashed(string password, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}