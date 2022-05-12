namespace DocuSign.Tsp.Model
{
    public class SignatureOAuthUserToken
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string user_api { get; set; }

        public int? expires_in { get; set; }
    }
}
