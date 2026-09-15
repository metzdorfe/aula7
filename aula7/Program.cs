using System;
using System.Collections.Generic;

namespace aula7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercicio 1
            Instrumento guitarra = new Guitarra("Fender");
            Instrumento piano = new Piano("Yamaha");
            guitarra.Tocar();
            piano.Tocar();
            Console.WriteLine();

            // Exercicio 2
            Eletrodomestico geladeira = new Geladeira("Brastemp");
            Eletrodomestico microondas = new Microondas("Electrolux");
            Eletrodomestico arCondicionado = new ArCondicionado("LG");
            geladeira.Ligar();
            microondas.Ligar();
            arCondicionado.Ligar();
            geladeira.ExibirVoltagem();
            Console.WriteLine();

            // Exercicio 3
            IImpressora laser = new ImpressoraLaser();
            IImpressora jato = new ImpressoraJatoDeTinta();
            IImpressora termica = new ImpressoraTermica();
            laser.Imprimir("Relatorio mensal");
            jato.Imprimir("Foto de familia");
            termica.Imprimir("Cupom fiscal");
            Console.WriteLine();

            // Exercicio 4
            Nadador nadador = new Nadador("Fernando");
            Ciclista ciclista = new Ciclista("Marcos");
            Console.WriteLine(nadador.Nome + " - Pontuacao: " + nadador.CalcularPontuacao() + " Premio: " + nadador.CalcularPremio());
            Console.WriteLine(ciclista.Nome + " - Pontuacao: " + ciclista.CalcularPontuacao() + " Premio: " + ciclista.CalcularPremio());
            Console.WriteLine();

            // Exercicio 5
            IAcesso acessoFuncionario = new AcessoFuncionario();
            IAcesso acessoVisitante = new AcessoVisitante();
            acessoFuncionario.Entrar("func01", "senha123");
            acessoFuncionario.Entrar("func01", "senhaErrada");
            acessoVisitante.Entrar("visitante", "livre");
            Console.WriteLine();

            // Exercicio 6
            Guerreiro guerreiro = new Guerreiro();
            Arqueiro arqueiro = new Arqueiro();
            guerreiro.Atacar();
            guerreiro.Defender();
            arqueiro.Atacar();
            Console.WriteLine();

            // Exercicio 7
            Produto produtoNormal = new ProdutoNormal("Caneta", 10);
            Produto produtoAtacado = new ProdutoAtacado("Caixa de Papel", 5, 20);
            produtoNormal.Repor(5);
            produtoNormal.Vender(20);
            produtoAtacado.Repor(5);
            produtoAtacado.Vender(20);
            Console.WriteLine();

            // Exercicio 8
            List<IAlerta> alertas = new List<IAlerta>();
            alertas.Add(new AlertaSonoro());
            alertas.Add(new AlertaVisual());
            alertas.Add(new AlertaPush());
            foreach (IAlerta a in alertas)
            {
                a.Disparar("Temperatura acima do normal!");
            }
            Console.WriteLine();

            // Exercicio 9
            List<IVolume> solidos = new List<IVolume>();
            solidos.Add(new Cubo(3));
            solidos.Add(new Esfera(2));
            solidos.Add(new Cilindro(2, 5));
            foreach (IVolume solido in solidos)
            {
                Console.WriteLine(solido.GetType().Name + " volume: " + solido.CalcularVolume());
            }
            Console.WriteLine();

            // Exercicio 10
            List<Equipamento> equipamentos = new List<Equipamento>();
            equipamentos.Add(new Esteira("Movement"));
            equipamentos.Add(new Bicicleta("Spinning Pro"));
            equipamentos.Add(new Halter("Anilha 10kg"));

            foreach (Equipamento e in equipamentos)
            {
                e.ExibirInformacoes();

                if (e is IManutencao manutencao)
                    manutencao.RealizarManutencao();

                if (e is ISupervisao supervisao)
                    supervisao.Supervisionar();

                Console.WriteLine();
            }

            // Desafio extra
            List<double> notasJogador1 = new List<double>();
            notasJogador1.Add(7.0);
            notasJogador1.Add(8.5);
            notasJogador1.Add(9.0);

            List<double> notasJogador2 = new List<double>();
            notasJogador2.Add(6.0);
            notasJogador2.Add(7.5);
            notasJogador2.Add(6.5);

            List<MembroTime> time = new List<MembroTime>();
            time.Add(new Jogador("Lucas", notasJogador1));
            time.Add(new Jogador("Bruno", notasJogador2));
            time.Add(new Tecnico("Ricardo", "4-3-3"));

            foreach (MembroTime membro in time)
            {
                membro.Apresentar();

                if (membro is IAvaliavel avaliavel)
                {
                    Console.WriteLine("Media final: " + avaliavel.CalcularMedia());
                }
            }
        }
    }

    // Exercicio 1
    public abstract class Instrumento
    {
        public string Nome { get; set; }

        public Instrumento(string nome)
        {
            Nome = nome;
        }

        public abstract void Tocar();
    }

    public class Guitarra : Instrumento
    {
        public Guitarra(string nome) : base(nome) { }

        public override void Tocar()
        {
            Console.WriteLine(Nome + " (Guitarra) toca um riff distorcido.");
        }
    }

    public class Piano : Instrumento
    {
        public Piano(string nome) : base(nome) { }

        public override void Tocar()
        {
            Console.WriteLine(Nome + " (Piano) toca um acorde suave.");
        }
    }

    // Exercicio 2
    public abstract class Eletrodomestico
    {
        public string Modelo { get; set; }

        public Eletrodomestico(string modelo)
        {
            Modelo = modelo;
        }

        public abstract void Ligar();

        public void ExibirVoltagem()
        {
            Console.WriteLine(Modelo + " funciona em 220V.");
        }
    }

    public class Geladeira : Eletrodomestico
    {
        public Geladeira(string modelo) : base(modelo) { }

        public override void Ligar()
        {
            Console.WriteLine(Modelo + " (Geladeira) foi ligada e comeca a resfriar.");
        }
    }

    public class Microondas : Eletrodomestico
    {
        public Microondas(string modelo) : base(modelo) { }

        public override void Ligar()
        {
            Console.WriteLine(Modelo + " (Microondas) foi ligado.");
        }
    }

    public class ArCondicionado : Eletrodomestico
    {
        public ArCondicionado(string modelo) : base(modelo) { }

        public override void Ligar()
        {
            Console.WriteLine(Modelo + " (Ar Condicionado) foi ligado e comeca a refrigerar.");
        }
    }

    // Exercicio 3
    public interface IImpressora
    {
        void Imprimir(string documento);
    }

    public class ImpressoraLaser : IImpressora
    {
        public void Imprimir(string documento)
        {
            Console.WriteLine("Imprimindo \"" + documento + "\" na impressora Laser.");
        }
    }

    public class ImpressoraJatoDeTinta : IImpressora
    {
        public void Imprimir(string documento)
        {
            Console.WriteLine("Imprimindo \"" + documento + "\" na impressora Jato de Tinta.");
        }
    }

    public class ImpressoraTermica : IImpressora
    {
        public void Imprimir(string documento)
        {
            Console.WriteLine("Imprimindo \"" + documento + "\" na impressora Termica.");
        }
    }

    // Exercicio 4
    public abstract class Atleta
    {
        public string Nome { get; set; }

        public Atleta(string nome)
        {
            Nome = nome;
        }

        public abstract double CalcularPontuacao();
    }

    public interface IPremiacao
    {
        double CalcularPremio();
    }

    public class Nadador : Atleta, IPremiacao
    {
        public Nadador(string nome) : base(nome) { }

        public override double CalcularPontuacao()
        {
            return 95.0;
        }

        public double CalcularPremio()
        {
            return CalcularPontuacao() * 100;
        }
    }

    public class Ciclista : Atleta, IPremiacao
    {
        public Ciclista(string nome) : base(nome) { }

        public override double CalcularPontuacao()
        {
            return 88.0;
        }

        public double CalcularPremio()
        {
            return CalcularPontuacao() * 80;
        }
    }

    // Exercicio 5
    public interface IAcesso
    {
        bool Entrar(string usuario, string senha);
    }

    public class AcessoFuncionario : IAcesso
    {
        public bool Entrar(string usuario, string senha)
        {
            bool valido = usuario == "func01" && senha == "senha123";
            if (valido)
                Console.WriteLine("Acesso de funcionario liberado.");
            else
                Console.WriteLine("Acesso de funcionario negado.");
            return valido;
        }
    }

    public class AcessoVisitante : IAcesso
    {
        public bool Entrar(string usuario, string senha)
        {
            Console.WriteLine("Acesso de visitante liberado com restricoes.");
            return true;
        }
    }

    // Exercicio 6
    public interface IAtaca
    {
        void Atacar();
    }

    public interface IDefende
    {
        void Defender();
    }

    public class Guerreiro : IAtaca, IDefende
    {
        public void Atacar()
        {
            Console.WriteLine("O guerreiro ataca com a espada.");
        }

        public void Defender()
        {
            Console.WriteLine("O guerreiro se defende com o escudo.");
        }
    }

    public class Arqueiro : IAtaca
    {
        public void Atacar()
        {
            Console.WriteLine("O arqueiro atira uma flecha.");
        }
    }

    // Exercicio 7
    public abstract class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; protected set; }

        public Produto(string nome, int quantidadeInicial)
        {
            Nome = nome;
            Quantidade = quantidadeInicial;
        }

        public abstract void Vender(int qtd);

        public void Repor(int qtd)
        {
            Quantidade += qtd;
            Console.WriteLine(Nome + " repos " + qtd + ". Estoque atual: " + Quantidade);
        }
    }

    public class ProdutoNormal : Produto
    {
        public ProdutoNormal(string nome, int quantidadeInicial) : base(nome, quantidadeInicial) { }

        public override void Vender(int qtd)
        {
            if (qtd <= Quantidade)
            {
                Quantidade -= qtd;
                Console.WriteLine(Nome + " vendeu " + qtd + ". Estoque atual: " + Quantidade);
            }
            else
            {
                Console.WriteLine(Nome + ": venda negada, estoque insuficiente.");
            }
        }
    }

    public class ProdutoAtacado : Produto
    {
        public int LimiteEncomenda { get; set; }

        public ProdutoAtacado(string nome, int quantidadeInicial, int limiteEncomenda) : base(nome, quantidadeInicial)
        {
            LimiteEncomenda = limiteEncomenda;
        }

        public override void Vender(int qtd)
        {
            if (qtd <= Quantidade + LimiteEncomenda)
            {
                Quantidade -= qtd;
                Console.WriteLine(Nome + " vendeu " + qtd + " (usando encomenda se preciso). Estoque atual: " + Quantidade);
            }
            else
            {
                Console.WriteLine(Nome + ": venda negada, excede estoque + limite de encomenda.");
            }
        }
    }

    // Exercicio 8
    public interface IAlerta
    {
        void Disparar(string mensagem);
    }

    public class AlertaSonoro : IAlerta
    {
        public void Disparar(string mensagem)
        {
            Console.WriteLine("Alerta sonoro: " + mensagem);
        }
    }

    public class AlertaVisual : IAlerta
    {
        public void Disparar(string mensagem)
        {
            Console.WriteLine("Alerta visual: " + mensagem);
        }
    }

    public class AlertaPush : IAlerta
    {
        public void Disparar(string mensagem)
        {
            Console.WriteLine("Alerta push: " + mensagem);
        }
    }

    // Exercicio 9
    public interface IVolume
    {
        double CalcularVolume();
    }

    public class Cubo : IVolume
    {
        public double Lado { get; set; }

        public Cubo(double lado)
        {
            Lado = lado;
        }

        public double CalcularVolume()
        {
            return Lado * Lado * Lado;
        }
    }

    public class Esfera : IVolume
    {
        public double Raio { get; set; }

        public Esfera(double raio)
        {
            Raio = raio;
        }

        public double CalcularVolume()
        {
            return (4.0 / 3.0) * Math.PI * Raio * Raio * Raio;
        }
    }

    public class Cilindro : IVolume
    {
        public double Raio { get; set; }
        public double Altura { get; set; }

        public Cilindro(double raio, double altura)
        {
            Raio = raio;
            Altura = altura;
        }

        public double CalcularVolume()
        {
            return Math.PI * Raio * Raio * Altura;
        }
    }

    // Exercicio 10
    public interface IManutencao
    {
        void RealizarManutencao();
    }

    public interface ISupervisao
    {
        void Supervisionar();
    }

    public abstract class Equipamento
    {
        public string Nome { get; set; }

        public Equipamento(string nome)
        {
            Nome = nome;
        }

        public abstract void ExibirInformacoes();
    }

    public class Esteira : Equipamento, IManutencao, ISupervisao
    {
        public Esteira(string nome) : base(nome) { }

        public override void ExibirInformacoes()
        {
            Console.WriteLine(Nome + " e uma Esteira.");
        }

        public void RealizarManutencao()
        {
            Console.WriteLine(Nome + ": manutencao da correia feita.");
        }

        public void Supervisionar()
        {
            Console.WriteLine(Nome + " esta sendo supervisionada durante o uso.");
        }
    }

    public class Bicicleta : Equipamento, IManutencao, ISupervisao
    {
        public Bicicleta(string nome) : base(nome) { }

        public override void ExibirInformacoes()
        {
            Console.WriteLine(Nome + " e uma Bicicleta ergometrica.");
        }

        public void RealizarManutencao()
        {
            Console.WriteLine(Nome + ": manutencao dos pedais feita.");
        }

        public void Supervisionar()
        {
            Console.WriteLine(Nome + " esta sendo supervisionada durante o uso.");
        }
    }

    public class Halter : Equipamento, IManutencao
    {
        public Halter(string nome) : base(nome) { }

        public override void ExibirInformacoes()
        {
            Console.WriteLine(Nome + " e um Halter.");
        }

        public void RealizarManutencao()
        {
            Console.WriteLine(Nome + ": verificacao de desgaste feita.");
        }
    }

    // Desafio extra
    public interface IAvaliavel
    {
        double CalcularMedia();
    }

    public abstract class MembroTime
    {
        public string Nome { get; set; }

        public MembroTime(string nome)
        {
            Nome = nome;
        }

        public abstract void Apresentar();
    }

    public class Jogador : MembroTime, IAvaliavel
    {
        private List<double> Notas;

        public Jogador(string nome, List<double> notas) : base(nome)
        {
            Notas = notas;
        }

        public override void Apresentar()
        {
            Console.WriteLine("Jogador: " + Nome);
        }

        public double CalcularMedia()
        {
            double soma = 0;
            foreach (double nota in Notas)
                soma += nota;
            return soma / Notas.Count;
        }
    }

    public class Tecnico : MembroTime
    {
        public string Formacao { get; set; }

        public Tecnico(string nome, string formacao) : base(nome)
        {
            Formacao = formacao;
        }

        public override void Apresentar()
        {
            Console.WriteLine("Tecnico: " + Nome + " (formacao: " + Formacao + ")");
        }
    }
}