using BolsaValores.Enums;
using BolsaValores.Models;

var acoes = new Dictionary<string, Acao>();
var investidores = new Dictionary<string, Investidor>();

ExecutarMenu();

void ExecutarMenu()
{
    while (true)
    {
        ExibirOpcoes();
        var opcao = LerEntrada(">");

        switch (opcao)
        {
            case "1": CriarAcao(); break;
            case "2": CriarInvestidor(); break;
            case "3": RegistrarOrdem(); break;
            case "4": AcompanharAcao(); break;
            case "5": ProgramarOrdem(); break;
            case "6": ListarAcoes(); break;
            case "0": return;
        }
    }
}

void ExibirOpcoes()
{
    Console.WriteLine();
    Console.WriteLine("[1] Criar ação");
    Console.WriteLine("[2] Criar investidor");
    Console.WriteLine("[3] Registrar ordem");
    Console.WriteLine("[4] Acompanhar ação");
    Console.WriteLine("[5] Programar ordem");
    Console.WriteLine("[6] Listar ações");
    Console.WriteLine("[0] Sair");
}

void CriarAcao()
{
    var nome = LerEntrada("Nome da ação").ToUpper();
    var valor = LerDecimal("Valor inicial");
    if (valor <= 0) return;

    acoes[nome] = new Acao(nome, new Dinheiro(valor));
    Console.WriteLine($"  Ação {nome} criada - {acoes[nome].ValorAtual}");
}

void CriarInvestidor()
{
    var nome = LerEntrada("Nome do investidor");

    investidores[nome] = new Investidor(nome);
    Console.WriteLine($"  Investidor '{nome}' criado");
}

void RegistrarOrdem()
{
    var investidor = SelecionarInvestidor();
    var acao = SelecionarAcao();
    if (investidor is null || acao is null) return;

    var tipo = LerTipoOrdem();
    var valor = LerDecimal("Valor da ordem");
    if (valor <= 0) return;

    investidor.RegistrarOrdem(acao, tipo, new Dinheiro(valor));
    Console.WriteLine($"  {acao.Nome}: valor={acao.ValorAtual} | ordens pendentes={acao.Ordens.Count}");
}

void AcompanharAcao()
{
    var investidor = SelecionarInvestidor();
    var acao = SelecionarAcao();
    if (investidor is null || acao is null) return;

    investidor.AcompanharAcao(acao);
    Console.WriteLine($"  '{investidor.Nome}' agora acompanha {acao.Nome}");
}

void ProgramarOrdem()
{
    var investidor = SelecionarInvestidor();
    var acao = SelecionarAcao();
    if (investidor is null || acao is null) return;

    var gatilho = LerDecimal("Valor gatilho");
    var tipo = LerTipoOrdem();
    var valor = LerDecimal("Valor da ordem");
    if (gatilho <= 0 || valor <= 0) return;

    investidor.ProgramarOrdem(acao, new Dinheiro(gatilho), tipo, new Dinheiro(valor));
    Console.WriteLine($"  Programada: {tipo} em {acao.Nome} a R${valor} quando atingir R${gatilho}");
}

void ListarAcoes()
{
    if (acoes.Count == 0)
    {
        Console.WriteLine("  Nenhuma ação cadastrada.");
        return;
    }

    foreach (var acao in acoes.Values)
    {
        Console.WriteLine($"  {acao.Nome} - {acao.ValorAtual} - {acao.Ordens.Count} ordens");
    }
}

// --- Métodos auxiliares ---

string LerEntrada(string rotulo)
{
    Console.Write($"{rotulo}: ");
    return Console.ReadLine()?.Trim() ?? "";
}

decimal LerDecimal(string rotulo)
{
    var input = LerEntrada(rotulo);
    if (decimal.TryParse(input, out var valor))
        return valor;

    Console.WriteLine("  Valor inválido.");
    return 0;
}

TipoOrdem LerTipoOrdem()
{
    var input = LerEntrada("Tipo (C=Compra, V=Venda)").ToUpper();
    return input == "V" ? TipoOrdem.Venda : TipoOrdem.Compra;
}

Investidor? SelecionarInvestidor()
{
    var nome = LerEntrada($"Investidor ({string.Join(", ", investidores.Keys)})");

    if (investidores.TryGetValue(nome, out var investidor))
        return investidor;

    Console.WriteLine("  Investidor não encontrado.");
    return null;
}

Acao? SelecionarAcao()
{
    var nome = LerEntrada($"Ação ({string.Join(", ", acoes.Keys)})").ToUpper();

    if (acoes.TryGetValue(nome, out var acao))
        return acao;

    Console.WriteLine("  Ação não encontrada.");
    return null;
}
