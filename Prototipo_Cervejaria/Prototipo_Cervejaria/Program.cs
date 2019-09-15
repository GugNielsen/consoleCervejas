using System;
using Prototipo_Cervejaria.ModelelosImplementados;

namespace Prototipo_Cervejaria
{
    class Program
    {
        static void Main(string[] args)
        {
            bool _isLogado = true;
            var us = new ActionRepository();

            // Iniciando o Pograma
            Ininal();
            void Ininal()
            {
                // Loop
                while (_isLogado)
                {
                    #region opções
                    // Limpar a Console 
                    Console.Clear();
                    // Saida de Dados 
                    Console.WriteLine("Digite 1 para adcionar produto do Stoque");
                    Console.WriteLine();
                    // Saida de Dados 
                    Console.WriteLine("Digite 2 para  verificar   o seu  Stoque");
                    Console.WriteLine();
                    // Saida de Dados 
                    Console.WriteLine("Digite 3 para  Consumir Produto  do Stoque");
                    Console.WriteLine();
                    // Saida de Dados 
                    Console.WriteLine("Digite 4 para  sair do Programa");
                    Console.WriteLine();
                    // Saida de Dados 
                    Console.Write("Digite Uma Opção: ");
                    // Entrada  de Dados para digitar
                    int opc = int.Parse(Console.ReadLine());
                    #endregion

                    //se digitar 1
                    if (opc == 1)
                    {
                        // Vai ate a Classe de User
                        //  para adicionar o item 
                        us.Validadeted();
                    }

                    //se digitar 2
                    else if (opc == 2)
                    {
                        // Vai ate a Classe de User
                        //  Verificar os Itens já add
                        us.VerificarStoque();
                    }

                    //se digitar 3
                    else if (opc == 3)
                    {
                        // Vai ate a Classe de User
                        //  Consumir o Item
                        us.IsConsumindoStoke();
                    }

                    //  //se digitar 4
                    else if (opc == 4)
                    { // limpar o Console
                        Console.Clear();
                        // ir no metedo desta classe aqui em baixo
                        // preguntar se que se quer fechar o programa
                        endProgran();
                        #region metodo Verificar Se o Programa sera Finalizado 
                        void endProgran()
                        {
                            // Saida de Dados 
                            Console.WriteLine("Deseja Sair do Programa do Programa s/ sim ou  n/ não");

                            // entrada de dados para digitar
                            var valid = Console.ReadLine();

                            // se digitar for S ou S 
                            if (valid == "s" || valid == "S")
                            {
                                // Saida de Dados 
                                Console.WriteLine("Programa Sera Finalizado");

                                // passando _IsLogado para False e treimando o Lupe 
                                _isLogado = false;

                                // saida de Dados
                                Console.WriteLine("Digite Qualquer Tecla para finalizar o Programa");
                                Console.ReadLine();

                                // end 
                            }
                            // se digitar N ou n 
                            else if (valid == "n" || valid == "N")
                            {
                                // mantera Logado
                                _isLogado = true;

                                // limapr o Console 
                                Console.Clear();
                            }
                            // se nao digitar nem S/ S ou N/n
                            else
                            {
                                // Constinuara logado

                                // saida de dados 
                                Console.WriteLine("Cliquer Qualquer Tecla e Digite  as  Teclas s/ sim ou n p/ não");
                                Console.ReadKey();

                                // Limpar Console 
                                Console.Clear();

                                // Volta a pregunta da Linha 73
                                endProgran();
                            }
                        }
                        #endregion

                    }

                    // se  nenhma opção opção digitada voltara para menu da linha 14
                    else
                    {
                        //  Saida de Dados 
                        Console.WriteLine("Comando não encontrado");
                        //  Saida de Dados 
                        Console.WriteLine("digite qualquer teclar para voltar ao menu");
                        Console.ReadKey();
                        // voltando para Linha 14 
                        Ininal();
                    }
                }
            }
        }
    }
}
