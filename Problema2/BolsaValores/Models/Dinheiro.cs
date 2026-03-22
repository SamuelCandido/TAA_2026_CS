namespace BolsaValores.Models
{

    public sealed class Dinheiro : IEquatable<Dinheiro>
    {
        public decimal Quantia { get; }

        public Dinheiro(decimal quantia)
        {
            if (quantia <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantia), "O valor deve ser maior que zero.");

            Quantia = quantia;
        }

        public bool MesmoValor(Dinheiro outro) => Quantia == outro.Quantia;

        public bool Equals(Dinheiro? outro) => outro is not null && Quantia == outro.Quantia;

        public override bool Equals(object? obj) => Equals(obj as Dinheiro);

        public override int GetHashCode() => Quantia.GetHashCode();

        public static bool operator ==(Dinheiro? esquerda, Dinheiro? direita)
        {
            if (esquerda is null) return direita is null;
            return esquerda.Equals(direita);
        }

        public static bool operator !=(Dinheiro? esquerda, Dinheiro? direita) => !(esquerda == direita);

        public override string ToString() => $"R${Quantia:N2}";
    }
}
