using System;
using ExerciciosPOO;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        //Exercicio1();

        //Exercicio2();

        //Exercicio3();

        //Exercicio4();

        //Exercicio5();

        //Exercicio6();

    }


    public static void Exercicio1()
    {
        List<Pessoa> pobj_Pessoa = new List<Pessoa>();
        Pessoa obj_Pessoa = new Pessoa();

        for (int i = 0; i < 2; i++)
        {
            Pessoa obj_NovaPessoa = new Pessoa();

            Console.Write("Digite seu nome: ");
            obj_NovaPessoa.Nome = Console.ReadLine();

            Console.Write("Digite sua idade: ");
            obj_NovaPessoa.Idade = int.Parse(Console.ReadLine());

            pobj_Pessoa.Add(obj_NovaPessoa);
        }

        obj_Pessoa.ExibirInformacao(pobj_Pessoa);



        Pessoa obj_OlderPerson = obj_Pessoa.SearchPerson(pobj_Pessoa);

        obj_Pessoa.ShowOlderPerson(obj_OlderPerson);



        Console.ReadLine();
        Console.Clear();
    }

    public static void Exercicio2()
    {

        Funcionario obj_Funcionario = new Funcionario();
        List<Funcionario> pobj_Funcionario = new List<Funcionario>();

        for (int i = 0; i < 2; i++)
        {
            Funcionario nv_Funcionario = new Funcionario();
            Console.Write("Digite seu nome: ");
            nv_Funcionario.Nome = Console.ReadLine();

            Console.Write("Digite seu salário: ");
            nv_Funcionario.Salario = double.Parse(Console.ReadLine());

            pobj_Funcionario.Add(nv_Funcionario);
        }

        obj_Funcionario.infoFuncionario(pobj_Funcionario);

        double media_salario = obj_Funcionario.Media_Salario(pobj_Funcionario);

        Console.WriteLine("A média salarial dos funcionários é: {0}", media_salario);
        Console.ReadLine();
    }

    public static void Exercicio3()
    {
        int i_MudarQntd = 0;

        Estoque obj_Funcionario = new Estoque();
        List<Estoque> pobj_Estoque = new List<Estoque>();

        Console.Write("Adicione o nome de um produto: ");
        obj_Funcionario.Nome = Console.ReadLine();

        Console.Write("Adicione o preço de um produto: ");
        obj_Funcionario.Preco = double.Parse(Console.ReadLine());

        Console.Write("Adicione a quantidade em estoque: ");
        obj_Funcionario.Qntd = int.Parse(Console.ReadLine());

        pobj_Estoque.Add(obj_Funcionario);
        obj_Funcionario.ExibirDados();

        Console.WriteLine("\n1. Adicionar quantidade");
        Console.WriteLine("2. Remover quantidade");

        Console.Write("Escolha uma opção: ");
        int i_Opc = int.Parse(Console.ReadLine());

        switch (i_Opc)
        {
            case 1:
                Console.Write("Quantos produtos deseja adicionar: ");
                i_MudarQntd = int.Parse(Console.ReadLine());
                break;

            case 2:
                Console.Write("Quantos produtos deseja remover: ");
                i_MudarQntd = int.Parse(Console.ReadLine());
                break;
        }

        obj_Funcionario.MudarQntd(i_Opc, i_MudarQntd);

        obj_Funcionario.ExibirDados();
        Console.ReadLine();
    }

    public static void Exercicio4()
    {
        double d_Imposto = 0, d_Aumento = 0, d_Liquido = 0, d_SalarioFinal = 0;

        Funcionario obj_Funcionario = new Funcionario();

        Console.Write("Digite o nome do funcionário: ");
        obj_Funcionario.Nome = Console.ReadLine();

        Console.Write("Digite o salário: ");
        obj_Funcionario.Salario = double.Parse(Console.ReadLine());

        Console.Write("Digite o imposto: ");
        d_Imposto = double.Parse(Console.ReadLine());

        obj_Funcionario.ExibirDados();

        Console.WriteLine("Salário liquido: {0:c}", obj_Funcionario.Salario - d_Imposto);

        Console.Write("Digite a % que desejaria aumentar o salário: ");
        d_Aumento = double.Parse(Console.ReadLine());

        d_SalarioFinal = obj_Funcionario.SalarioFinal(d_Liquido, d_Imposto, d_Aumento);


        Console.WriteLine("Dados atualizados: {0}, {1:c}", obj_Funcionario.Nome, d_SalarioFinal);

        Console.ReadLine();

    }

    public static void Exercicio5()
    {

        List<Aluno> pobj_Aluno = new List<Aluno>();
        bool b_Condicao = false;

        do
        {
            //Interage com o Usuário para ele informar os Dados
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            double nota1, nota2, nota3;

            //Obtem as notas com um limitador nelas
            do
            {
                Console.Write("Digite a 1° nota do aluno (máximo 30): ");
                nota1 = double.Parse(Console.ReadLine());
            } while (nota1 < 0 || nota1 > 30);

            do
            {
                Console.Write("Digite a 2° nota do aluno (máximo 35): ");
                nota2 = double.Parse(Console.ReadLine());
            } while (nota2 < 0 || nota2 > 35);

            do
            {
                Console.Write("Digite a 3° nota do aluno (máximo 35): ");
                nota3 = double.Parse(Console.ReadLine());
            } while (nota3 < 0 || nota3 > 35);

            //Pega as informações digitada pelo usuário e cria um novo Aluno na List
            Aluno novoAluno = new Aluno(nome, nota1, nota2, nota3);
            pobj_Aluno.Add(novoAluno);

            //Verifica se o usuário gostaria de criar um novo Aluno
            Console.Write("Gostaria de criar outro Aluno? ");
            string resposta = Console.ReadLine();

            b_Condicao = resposta.ToUpper() == "SIM";

        } while (b_Condicao);


        //Carrega na tela as informações dos Alunos dentro da List "pobj_Aluno"
        foreach (var aluno in pobj_Aluno)
        {
            aluno.ExibirAlunos(pobj_Aluno);
        }
        Console.ReadLine();
    }

    public static void Exercicio6()
    {

        int x = 10;
        Calculator.Triple(ref x);
        Console.WriteLine(x);
        Console.ReadLine();
    }
}
