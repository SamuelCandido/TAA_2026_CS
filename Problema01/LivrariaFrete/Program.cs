using Problema01.LivrariaFrete.Enums;
using Problema01.LivrariaFrete.Factories;
using Problema01.LivrariaFrete.Models;
using Problema01.LivrariaFrete.Services;

var pedido = new Pedido();

Console.WriteLine("=== Cadastro de Produtos ===");
Console.WriteLine("Digite 'fim' para encerrar.\n");

while (true)
{
    Console.Write("Nome do produto: ");
    var nome = Console.ReadLine();

    if (nome?.ToLower() == "fim")
        break;

    Console.Write("Valor do produto: ");
    decimal valor = decimal.Parse(Console.ReadLine()!);

    Console.Write("Peso: ");
    decimal pesoValor = decimal.Parse(Console.ReadLine()!);

    Console.WriteLine("Unidade de peso:");
    Console.WriteLine("1 - Grama");
    Console.WriteLine("2 - Quilograma");
    Console.WriteLine("3 - Tonelada");

    int unidadeInput = int.Parse(Console.ReadLine()!);

    UnidadeDePesoEnum unidade = unidadeInput switch
    {
        1 => UnidadeDePesoEnum.GRAMA,
        2 => UnidadeDePesoEnum.QUILOGRAMA,
        3 => UnidadeDePesoEnum.TONELADA,
        _ => throw new Exception("Unidade inválida")
    };

    var peso = new Peso(pesoValor, unidade);
    var produto = new Produto(nome!, valor, peso);

    pedido.AdicionarProduto(produto);

    Console.WriteLine("Produto adicionado!\n");
}

Console.WriteLine("\n=== Tipo de Entrega ===");
Console.WriteLine("1 - PAC");
Console.WriteLine("2 - Sedex");
Console.WriteLine("3 - Retirada no local");

int tipoInput = int.Parse(Console.ReadLine()!);

TipoDeEntregaEnum tipoEntrega = tipoInput switch
{
    1 => TipoDeEntregaEnum.ENCOMENDA_PAC,
    2 => TipoDeEntregaEnum.SEDEX,
    3 => TipoDeEntregaEnum.RETIRADA_LOCAL,
    _ => throw new Exception("Tipo inválido")
};

var tipoDeEntregaObj = TipoDeEntregaFactory.CriarTipoDeEntrega(tipoEntrega);

var calculadora = new CalculadoraFreteService(tipoDeEntregaObj);

try
{
    decimal valorFrete = calculadora.Calcular(pedido);

    Console.WriteLine("\n=== Resultado ===");
    Console.WriteLine($"Peso total: {pedido.PesoTotal().EmQuilogramas:N2} kg");
    Console.WriteLine($"Valor do frete: R$ {valorFrete:N2}");
}
catch (Exception ex)
{
    Console.WriteLine($"\nErro: {ex.Message}");
}