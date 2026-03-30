namespace CasaSmart.Factories
{
    public class LampadaFactory
    {
        public static ILampada CriarLampada(TipoLampadaEnum tipo)
        {
            switch (tipo)
            {
                case TipoLampadaEnum.Phellipes:
                    return new LampadaPhellipesAdapter(new LampadaPhellipes());

                case TipoLampadaEnum.Shoyumi:
                    return new LampadaShoyuMiAdapter(new LampadaShoyuMi());

                default:
                    throw new ArgumentException("Tipo de lâmpada inválido");
            }
        }    
    }
}
