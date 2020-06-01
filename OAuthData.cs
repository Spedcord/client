namespace SpedcordClient
{
    public struct OAuthData
    {
        public string name;
        public string discriminator;
        public string avatar;

        public OAuthData(string name, string discriminator, string avatar)
        {
            this.name = name;
            this.discriminator = discriminator;
            this.avatar = avatar;
        }

        public bool Verify()
        {
            return name != null && discriminator != null && avatar != null;
        }
    }
}