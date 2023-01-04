namespace CMR.Api.Domain.Entities
{
    public abstract class BaseDomainCRM
    {
        public int Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime? DataAtualizacao { get; protected set; }
    }
}
