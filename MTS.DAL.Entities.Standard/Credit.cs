using MTS.BL.Infra.Interfaces.Standard;

namespace MTS.DAL.Entities.Standard
{
    public sealed class Credit : ICredit
    {
        public int Id { get; set; }
        public string MadeBy { get; set; }
        public string GotFrom { get; set; }
        public string LinkToImage { get; set; }
        public string AuthorWebsite { get; set; }
    }
}
