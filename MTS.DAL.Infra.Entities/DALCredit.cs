namespace MTS.DAL.Entities.Core
{
    public sealed class DALCredit
    {
        public int Id { get; set; }
        public string MadeBy { get; set; }
        public string GotFrom { get; set; }
        public string LinkToImage { get; set; }
        public string AuthorWebsite { get; set; }
    }
}
