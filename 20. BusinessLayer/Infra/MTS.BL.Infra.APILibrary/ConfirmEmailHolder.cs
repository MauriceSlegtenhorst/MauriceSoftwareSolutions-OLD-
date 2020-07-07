using MTS.PL.Infra.Interfaces.Standard;

namespace MTS.PL.Entities.Standard
{
    public sealed class ConfirmEmailHolder : IConfirmEmailHolder
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
