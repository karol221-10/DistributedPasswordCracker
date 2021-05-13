namespace CrackServer.Services
{
    public class CrackObjectProvider
    {
        private byte[] hashContent;

        public CrackObjectProvider(byte[] hashContent)
        {
            this.hashContent = hashContent;
        }

        public byte[] HashContent { get => hashContent; set => hashContent = value; }
    }
}
