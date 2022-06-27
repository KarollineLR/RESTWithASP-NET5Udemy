using RESTWithASP_NET5Udemy.Configurations;
using RESTWithASP_NET5Udemy.Data.VO;
using RESTWithASP_NET5Udemy.Repository;
using RESTWithASP_NET5Udemy.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RESTWithASP_NET5Udemy.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;

        private IUserRepository _repository;
        private readonly ITokenServices _tokenServices;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenServices tokenServices)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenServices = tokenServices;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if(user == null)return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accesseToken = _tokenServices.GenerateAccessToken(claims);
            var refreshToken = _tokenServices.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            //DateTime futureDate = DateTime.Now.AddHours(3);
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accesseToken,
                refreshToken
                );
        }
    }
}
