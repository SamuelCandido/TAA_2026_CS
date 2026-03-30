namespace CasaSmart.Factories
{
    public class PersianaFactory
    {        
        public static IPersiana CriarPersiana(TipoPersianaEnum tipo)
        {
            switch (tipo)
            {
                case TipoPersianaEnum.Solarius:
                    return new PersianaSolariusAdapter(new PersianaSolarius());

                case TipoPersianaEnum.Natlight:
                    return new PersianaNatLightAdapter(new PersianaNatLight());

                default:
                    throw new ArgumentException("Tipo de persiana inválido");
            }
        }
    }
}