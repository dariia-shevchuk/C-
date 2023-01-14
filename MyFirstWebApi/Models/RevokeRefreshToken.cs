namespace MyFirstWebApi.Models
{
    public class RevokeRefreshToken
    {
        public RevokeRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public string RefreshToken { get; set; }
    }
}